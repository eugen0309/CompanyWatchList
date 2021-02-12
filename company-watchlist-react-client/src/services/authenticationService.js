import { BehaviorSubject } from "rxjs";
import { handleResponse } from "../helpers/handle-response";

const currentUserSubject = new BehaviorSubject(
  JSON.parse(localStorage.getItem("currentUser"))
);

export const authenticationService = {
  login(username, password) {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password }),
    };
    return fetch(
      `${process.env.REACT_APP_API_URL}/users/authenticate`,
      requestOptions
    )
      .then(handleResponse)
      .then((user) => {
        localStorage.setItem("currentUser", JSON.stringify(user));
        currentUserSubject.next(user);

        return user;
      });
  },
  logout() {
    localStorage.removeItem("currentUser");
    currentUserSubject.next(null);
  },
  currentUser: currentUserSubject.asObservable(),
  get currentUserValue() {
    return currentUserSubject.value;
  },
};
