import React, { useState, useEffect } from "react";
import { userService } from "../../services/userService";
import { authenticationService } from "../../services/authenticationService";
import { Role } from "../../helpers/role";
import { withRouter } from "react-router-dom";
import {
  Table,
  Button,
  message,
  Popconfirm,
  Row,
  Modal,
  Input,
  Select,
  Form,
} from "antd";

function AdminPage(props) {
  const [users, setUsers] = useState();
  const [usersChanged, setUsersChanged] = useState(false);
  const [addUserModalVisible, setAddUserModalVisible] = useState(false);
  const [newUserName, setNewUserName] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordConfirm, setPasswordConfirm] = useState("");
  const [role, setRole] = useState(Role.User);

  const Option = Select.Option;
  const FormItem = Form.Item;

  useEffect(() => {
    getUsers();
    async function getUsers() {
      const apiUsers = await userService.getAll();
      setUsers(apiUsers);
    }
  }, [usersChanged]);

  const columns = [
    {
      title: "User Name",
      dataIndex: "userName",
      key: "name",
      render: (text) => text,
    },
    {
      title: "First Name",
      dataIndex: "firstName",
      key: "firstname",
      render: (text) => text,
    },
    {
      title: "Last Name",
      dataIndex: "lastName",
      key: "lastname",
      render: (text) => text,
    },
    {
      title: "Remove",
      key: "add",
      render: (text, record) => {
        const currentUser = authenticationService.currentUserValue;
        return currentUser.id !== record.id ? (
          <Popconfirm
            title="Are you sure?"
            okText="Yes!"
            cancelText="Cancel"
            onConfirm={async () => await removeUser(record)}
          >
            <Button type="danger">Delete user</Button>
          </Popconfirm>
        ) : (
          <Button disabled type="danger">
            Delete user
          </Button>
        );
      },
    },
  ];

  function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

  async function removeUser(record) {
    const result = await userService.deleteUser(record.id);
    if (result === 200) {
      message.success("User removed!");
    } else {
      message.error("Couldn't remove user!");
    }
    setUsersChanged(!usersChanged);
  }

  async function addUser() {
    if (password !== passwordConfirm) {
      message.error("The passwords do not match!");
      return;
    }
    const user = await userService.getByName(newUserName);
    if (user !== undefined) {
      message.error("User name already exists! Please select another one.");
    }
    const response = await userService.addUser({
      userName: newUserName,
      firstName: firstName,
      lastName: lastName,
      emailAddress: email,
      password: password,
      userRoles: [role],
    });
    if (response === 200) {
      message.success("User created!");
      setAddUserModalVisible(false);
      setUsersChanged(!usersChanged);
    }
  }

  return (
    <div>
      <h1>Users</h1>

      <Row style={{ marginBottom: "10px" }}>
        <Button type="primary" onClick={() => setAddUserModalVisible(true)}>
          Add user
        </Button>
      </Row>
      <Table columns={columns} dataSource={users}></Table>
      <Modal
        visible={addUserModalVisible}
        onCancel={() => setAddUserModalVisible(false)}
        onOk={async () => await addUser()}
        okText="Add"
        destroyOnClose
      >
        <Form>
          <FormItem
            requiredMark
            validateStatus={newUserName === "" ? "error" : "success"}
          >
            <Row style={{ margin: "15px" }}>
              User name:{" "}
              <Input
                required
                placeholder="Username"
                onChange={(e) => setNewUserName(e.target.value)}
              ></Input>
            </Row>
          </FormItem>
          <FormItem
            required
            requiredMark
            validateStatus={firstName === "" ? "error" : "success"}
          >
            <Row style={{ margin: "15px" }}>
              First name:{" "}
              <Input
                placeholder="First Name"
                onChange={(e) => setFirstName(e.target.value)}
              ></Input>
            </Row>
          </FormItem>
          <FormItem
            requiredMark
            required
            validateStatus={lastName === "" ? "error" : "success"}
          >
            <Row style={{ margin: "15px" }}>
              Last name:{" "}
              <Input
                placeholder="Last Name"
                onChange={(e) => setLastName(e.target.value)}
              ></Input>
            </Row>
          </FormItem>
          <FormItem
            requiredMark
            required
            validateStatus={!validateEmail(email) ? "error" : "success"}
          >
            <Row style={{ margin: "15px" }}>
              Email address:{" "}
              <Input
                placeholder="Email@website.com"
                onChange={(e) => setEmail(e.target.value)}
              ></Input>
            </Row>
          </FormItem>
          <FormItem>
            <Row style={{ margin: "15px" }}>
              Password:{" "}
              <Input.Password
                placeholder="Password"
                onChange={(e) => setPassword(e.target.value)}
              ></Input.Password>
            </Row>
          </FormItem>
          <FormItem>
            <Row style={{ margin: "15px" }}>
              Confirm:{" "}
              <Input.Password
                placeholder="Confirm password"
                onChange={(e) => setPasswordConfirm(e.target.value)}
              ></Input.Password>
            </Row>
          </FormItem>
          <FormItem>
            <Row style={{ margin: "15px" }}>
              Role:{" "}
              <Select
                defaultValue={Role.User}
                onSelect={(x) => setRole(x)}
                style={{ width: "100%" }}
              >
                <Option value={Role.User}>{Role.User}</Option>
                <Option value={Role.Admin}>{Role.Admin}</Option>
              </Select>
            </Row>
          </FormItem>
        </Form>
      </Modal>
    </div>
  );
}

export default withRouter(AdminPage);
