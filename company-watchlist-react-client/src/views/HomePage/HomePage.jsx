import React, { useState, useEffect } from "react";
import { authenticationService } from "../../services/authenticationService";
import { watchlistService } from "../../services/watchlistService";
import { userService } from "../../services/userService";
import { withRouter } from "react-router-dom";
import SearchComponent from "../../components/SearchComponent";
import { Divider, message } from "antd";
import WatchListComponent from "../../components/WatchListComponent";

function HomePage(props) {
  const [currentUser, setCurrentUser] = useState(
    authenticationService.currentUserValue
  );
  const [userFromApi, setUserFromApi] = useState();
  const [watchList, setWatchList] = useState();
  const [watchListChanged, setWatchListChanged] = useState(false);

  useEffect(() => {
    async function getUserFromApi() {
      const apiUser = await userService.getById(currentUser.id);
      setUserFromApi(apiUser);
    }

    getUserFromApi();
  }, [watchList]);

  async function removeFromWatchlist(company) {
    const companyId = (await watchlistService.getAll()).find(
      (c) => c.symbol === company.symbol
    ).id;
    const result = await watchlistService.unfollowCompany(companyId);
    if (result === 200) {
      message.success("Removed from watchlist");
      let newWatchList = watchList;
      newWatchList.splice(newWatchList.indexOf(company), 1);
      setWatchList(newWatchList);
      setWatchListChanged(!watchListChanged);
    } else {
      message.error("Failed!");
    }
  }

  return (
    <div>
      <h1>{(userFromApi || { firstName: "" }).firstName}'s watchlist</h1>
      <Divider orientation="left">Search for companies</Divider>
      <SearchComponent
        watchList={watchList}
        setWatchList={setWatchList}
        watchListChanged={watchListChanged}
        setWatchListChanged={setWatchListChanged}
        removeFromWatchlist={(company) => removeFromWatchlist(company)}
      />
      <br></br>
      <Divider orientation="left">My watchlist</Divider>
      <WatchListComponent
        watchList={watchList}
        setWatchList={setWatchList}
        watchListChanged={watchListChanged}
        setWatchListChanged={setWatchListChanged}
        removeFromWatchlist={(company) => removeFromWatchlist(company)}
      />
      <br></br>
      <br></br>
      <p>Logged in</p>
      <div>
        {(userFromApi || { firstName: "" }).firstName}{" "}
        {(userFromApi || { lastName: "" }).lastName}
      </div>
    </div>
  );
}

export default withRouter(HomePage);
