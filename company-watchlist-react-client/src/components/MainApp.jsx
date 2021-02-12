import React, { useState, useEffect } from "react";
import { Route, NavLink, Switch, BrowserRouter } from "react-router-dom";
import { authenticationService } from "../services/authenticationService";

import { Role } from "../helpers/role";
import { history } from "../helpers/history";
import { PrivateRoute } from "./PrivateRoute";
import { LoginPage } from "../views/LoginPage/LoginPage";
import HomePage from "../views/HomePage/HomePage";
import AdminPage from "../views/AdminPage/AdminPage";
import { NotFoundPage } from "../views/404";

export function MainApp(props) {
  const [currentUser, setCurrentUser] = useState();
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(() => {
    authenticationService.currentUser.subscribe((x) => {
      setCurrentUser(x);
      setIsAdmin(x && x.roles.some((r) => r.name === Role.Admin));
    });
  }, []);

  function logout() {
    authenticationService.logout();
    history.push("/login");
  }

  return (
    <BrowserRouter history={history}>
      <div>
        {currentUser && (
          <nav className="navbar navbar-expand navbar-dark bg-dark">
            <div className="navbar-nav">
              <NavLink to="/" className="nav-item nav-link">
                Home
              </NavLink>
              {isAdmin && (
                <NavLink to="/admin" className="nav-item nav-link">
                  Admin
                </NavLink>
              )}
              <a onClick={logout} className="nav-item nav-link">
                Logout
              </a>
            </div>
          </nav>
        )}
        <div className="jumbotron">
          <div className="container">
            <div className="row">
              <div className="col-md-6 offset-md-3">
                <Switch>
                  <PrivateRoute exact path="/" component={HomePage} />
                  <PrivateRoute
                    path="/admin"
                    roles={[Role.Admin]}
                    component={AdminPage}
                  />
                  <Route exact path="/login" component={LoginPage} />
                  <Route path="*" component={NotFoundPage} />
                </Switch>
              </div>
            </div>
          </div>
        </div>
      </div>
    </BrowserRouter>
  );
}
