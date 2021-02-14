import { authHeader } from "../helpers/auth-header";

export const userService = {
  getAll,
  getById,
  getByName,
  addUser,
  deleteUser,
};
async function getAll() {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/users`,
    requestOptions
  );
  const data = await response.json();
  return data;
}

async function getById(id) {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/users/${id}`,
    requestOptions
  );
  const data = await response.json();
  return data;
}

async function getByName(userName) {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/users/${userName}`,
    requestOptions
  );
  if (response.status === 404) {
    return undefined;
  }
  const data = await response.json();
  return data;
}

async function addUser(userData) {
  const requestOptions = {
    method: "POST",
    headers: { ...authHeader(), "Content-Type": "application/json" },
    body: JSON.stringify({ ...userData }),
  };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Users/register`,
    requestOptions
  );
  return response.status;
}

async function deleteUser(userId) {
  const requestOptions = {
    method: "DELETE",
    headers: { ...authHeader() },
  };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Users/${userId}`,
    requestOptions
  );
  return response.status;
}
