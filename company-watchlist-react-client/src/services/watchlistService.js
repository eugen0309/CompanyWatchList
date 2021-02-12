import { authHeader } from "../helpers/auth-header";

export const userService = {
  getAll,
  getById,
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
