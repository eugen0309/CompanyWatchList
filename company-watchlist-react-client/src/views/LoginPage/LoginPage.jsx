import React, { useEffect } from "react";
import { Form, Input, Button, Checkbox, message } from "antd";
import "antd/dist/antd.css";
import { authenticationService } from "../../services/authenticationService";

export function LoginPage(props) {
  useEffect(() => {
    if (authenticationService.currentUserValue) {
      props.history.push("/");
    }
  }, []);

  const layout = {
    labelCol: {
      span: 8,
    },
    wrapperCol: {
      span: 16,
    },
  };
  const tailLayout = {
    wrapperCol: {
      offset: 8,
      span: 16,
    },
  };

  const onFinish = async (values) => {
    await authenticationService.login(values["username"], values["password"]);

    props.history.push("/");
  };

  const onFinishFailed = (errorInfo) => {};

  return (
    <Form
      {...layout}
      name="basic"
      initialValues={{
        remember: true,
      }}
      onFinish={async (values) => await onFinish(values)}
      onFinishFailed={onFinishFailed}
    >
      <Form.Item
        label="Username"
        name="username"
        rules={[
          {
            required: true,
            message: "Please input your username!",
          },
        ]}
      >
        <Input />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[
          {
            required: true,
            message: "Please input your password!",
          },
        ]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item {...tailLayout} name="remember" valuePropName="checked">
        <Checkbox>Remember me</Checkbox>
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
}
