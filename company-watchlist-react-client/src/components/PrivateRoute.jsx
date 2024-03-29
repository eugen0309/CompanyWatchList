import React from "react";
import { Route, Redirect } from "react-router-dom";
import { Component } from "react/cjs/react.production.min";
import { authenticationService } from "../services/authenticationService";

export const PrivateRoute = ({ component: Component, roles, ...rest }) => (
  <Route
    {...rest}
    render={(props) => {
      const currentUser = authenticationService.currentUserValue;
      if (!currentUser) {
        return (
          <Redirect
            to={{ pathname: "/login", state: { from: props.location } }}
          />
        );
      }

      if (
        roles &&
        roles.filter((value) => currentUser.roles.includes(value)).length === 0
      ) {
        return <Redirect to={{ pathname: "/" }} />;
      }
      return <Component {...props} />;
    }}
  />
);
