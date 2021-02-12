import React, { useState, useEffect } from "react";
import { userService } from "../../services/userService";
import { withRouter } from "react-router-dom";

function AdminPage(props) {
  const [users, setUsers] = useState();

  useEffect(() => {
    getUsers();
    async function getUsers() {
      const apiUsers = await userService.getAll();
      setUsers(apiUsers);
    }
  }, []);

  return (
    <div>
      <h1>Admin</h1>
      <p>This page can only be accessed by administrators.</p>
      <div>
        All users from secure (admin only) api end point:
        {users && (
          <ul>
            {users.map((user) => (
              <li key={user.id}>
                {user.firstName} {user.lastName}
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}

export default withRouter(AdminPage);
