import React, { Fragment, useState, useEffect } from "react";
import { Table, Button, message } from "antd";
import { watchlistService } from "../services/watchlistService";

export default function WatchListComponent(props) {
  const [tableData, setTableData] = useState([]);
  //const [watchListChanged, setWatchListChanged] = useState(false);
  useEffect(() => {
    async function populateWatchList() {
      const items = await watchlistService.getAll();
      props.setWatchList(items);
    }
    if (props.watchList === undefined) {
      populateWatchList();
      return;
    }
    const newTableData = props.watchList.map((item) => {
      return {
        name: item.name,
        symbol: item.symbol,
        key: props.watchList.indexOf(item),
      };
    });
    setTableData(newTableData);
  }, [props.setWatchList, props.watchList, props.watchListChanged]);

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
      title: "Show details",
      key: "add",
      render: (text, record) => {
        return (
          <Button onClick={async () => {}} type="primary">
            Show details
          </Button>
        );
      },
    },
    {
      title: "Remove",
      key: "add",
      render: (text, record) => {
        return (
          <Button
            onClick={async () => {
              const watchlistItem = props.watchList.find(
                (item) => item.symbol === record.symbol
              );
              await props.removeFromWatchlist(watchlistItem);
            }}
            type="danger"
          >
            Remove from watchlist
          </Button>
        );
      },
    },
  ];

  return (
    <Fragment>
      <Table columns={columns} dataSource={tableData}></Table>
    </Fragment>
  );
}
