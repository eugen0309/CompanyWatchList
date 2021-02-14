import { authHeader } from "../helpers/auth-header";

export const watchlistService = {
  getAll,
  searchCompany,
  getDetails,
  followCompany,
  unfollowCompany,
};
async function getAll() {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Company`,
    requestOptions
  );
  const data = await response.json();
  return data;
}

async function searchCompany(keywords) {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Company/search/${keywords}`,
    requestOptions
  );
  const data = await response.json();
  return data;
}

async function getDetails(symbol) {
  const requestOptions = { method: "GET", headers: authHeader() };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Company/details/${symbol}`,
    requestOptions
  );
  const data = await response.json();
  return data;
}

async function followCompany(name, symbol) {
  const requestOptions = {
    method: "POST",
    headers: { ...authHeader(), "Content-Type": "application/json" },
    body: JSON.stringify({ name: name, symbol: symbol }),
  };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Company/follow`,
    requestOptions
  );
  return response.status;
}

async function unfollowCompany(companyId) {
  const requestOptions = {
    method: "DELETE",
    headers: { ...authHeader() },
  };
  const response = await fetch(
    `${process.env.REACT_APP_API_URL}/Company/unfollow/${companyId}`,
    requestOptions
  );
  return response.status;
}
