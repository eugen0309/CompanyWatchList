import React, { Fragment, useState, useEffect } from "react";
import { Input, Table, Button, message, Row } from "antd";
import { watchlistService } from "../services/watchlistService";
export default function SearchComponent(props) {
  const [keyword, setKeyword] = useState("");
  const [tableData, setTableData] = useState([]);
  //const [watchListChanged, setWatchListChanged] = useState(true);

  useEffect(() => {
    const delaySearchFn = setTimeout(async () => {
      if (keyword === null || keyword === undefined || keyword === "") {
        setTableData([]);
        return;
      }

      async function populateWatchList() {
        const items = await watchlistService.getAll();
        props.setWatchList(items);
      }
      if (props.watchList === undefined) {
        populateWatchList();
        return;
      }

      const searchResult = await watchlistService.searchCompany(keyword);
      if (searchResult === undefined) {
        return;
      }
      searchResult.map((r) => (r["key"] = searchResult.indexOf(r)));

      const tempTableData = searchResult.map((sr) => {
        return {
          key: sr.key,
          name: sr["2. name"],
          symbol: sr["1. symbol"],
          region: sr["4. region"],
          opening: sr["5. marketOpen"],
          closing: sr["6. marketClose"],
        };
      });

      //const tempWatchList = await watchlistService.getAll();

      //props.setWatchList(tempWatchList);
      setTableData(tempTableData);
    }, 800);
    return () => clearTimeout(delaySearchFn);
  }, [keyword, props.watchListChanged, props.setWatchList, props.watchList]);

  const columns = [
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
      render: (text) => text,
    },
    {
      title: "Symbol",
      dataIndex: "symbol",
      key: "symbol",
      render: (text) => text,
    },
    {
      title: "Region",
      dataIndex: "region",
      key: "region",
      render: (text) => text,
    },
    {
      title: "OpeningHours",
      dataIndex: "opening",
      key: "opening",
      render: (text) => text,
    },
    {
      title: "ClosingHours",
      dataIndex: "closing",
      key: "closing",
      render: (text) => text,
    },
    {
      title: "AddToWatchList",
      key: "add",
      render: (text, record) => {
        if (props.watchList.some((item) => item.symbol === record.symbol)) {
          return (
            <Button
              onClick={async () => {
                const company = props.watchList.find(
                  (item) => item.symbol === record.symbol
                );
                await props.removeFromWatchlist(company);
              }}
              type="danger"
            >
              Remove from watchlist
            </Button>
          );
        } else {
          return (
            <Button
              type="primary"
              onClick={async () => await addToWatchlist(record)}
            >
              Add to watchlist
            </Button>
          );
        }
      },
    },
  ];

  async function addToWatchlist(record) {
    const result = await watchlistService.followCompany(
      record.name,
      record.symbol
    );
    if (result === 200) {
      message.success("Added to watchlist");
      const newWatchList = props.watchList;
      newWatchList.push({ name: record.name, symbol: record.symbol });
      props.setWatchList(newWatchList);
      props.setWatchListChanged(!props.watchListChanged);
    } else {
      message.error("Failed!");
    }
  }

  async function removeFromWatchlist(company) {
    const result = await watchlistService.unfollowCompany(company.id);
    if (result === 200) {
      message.success("Removed from watchlist");
      const newWatchList = props.watchList;
      newWatchList.splice(newWatchList.indexOf(company), 1);
      props.setWatchList(newWatchList);
      props.setWatchListChanged(!props.watchListChanged);
    } else {
      message.error("Failed!");
    }
  }

  return (
    <Fragment>
      <Row style={{ marginBottom: "20px" }}>
        <Input
          allowClear
          style={{ width: 500 }}
          placeholder="Search companies"
          onChange={(e) => setKeyword(e.target.value)}
        ></Input>
      </Row>
      {tableData.length > 0 ? (
        <Table columns={columns} dataSource={tableData}></Table>
      ) : (
        <></>
      )}
    </Fragment>
  );
}
