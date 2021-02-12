import React, { useState, useEffect } from "react";
import { authenticationService } from "../../services/authenticationService";
import { userService } from "../../services/userService";
import { withRouter } from "react-router-dom";

function HomePage(props) {
  const [currentUser, setCurrentUser] = useState(
    authenticationService.currentUserValue
  );
  const [userFromApi, setUserFromApi] = useState();

  useEffect(() => {
    async function getUserFromApi() {
      const apiUser = await userService.getById(currentUser.id);
      setUserFromApi(apiUser);
    }

    getUserFromApi();
  }, []);

  return (
    <div>
      <h1>Home</h1>
      <p>Logged in</p>
      <p>This page can be accessed by all authenticated users.</p>
      <div>
        Current user from secure api end point:
        {userFromApi && (
          <div>
            {userFromApi.firstName} {userFromApi.lastName}
          </div>
        )}
      </div>
    </div>
  );
}

export default withRouter(HomePage);
