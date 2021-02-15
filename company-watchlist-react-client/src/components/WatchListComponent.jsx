import React, { Fragment, useState, useEffect } from "react";
import { Table, Button, message, Modal } from "antd";
import { watchlistService } from "../services/watchlistService";
import { camelCaseToWords } from "../helpers/string-utility";

export default function WatchListComponent(props) {
  const [tableData, setTableData] = useState([]);
  const [detailsModalVisible, setDetailsModalVisible] = useState(false);
  const [companyDetails, setCompanyDetails] = useState();

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
      title: "Show overview",
      key: "add",
      render: (text, record) => {
        return (
          <Button
            onClick={async () => await showCompanyDetails(record.symbol)}
            type="primary"
          >
            Show overview
          </Button>
        );
      },
    },
    {
      title: "Search details",
      key: "add",
      render: (text, record) => {
        return (
          <Button
            onClick={() => props.setKeyword(record.symbol)}
            type="primary"
          >
            Search details
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

  async function showCompanyDetails(symbol) {
    const details = await watchlistService.getDetails(symbol);
    setCompanyDetails(details);
    setDetailsModalVisible(true);
  }

  return (
    <Fragment>
      <Table columns={columns} dataSource={tableData}></Table>
      <Modal
        onOk={() => setDetailsModalVisible(false)}
        visible={detailsModalVisible}
        onCancel={() => setDetailsModalVisible(false)}
        destroyOnClose
      >
        {companyDetails ? (
          Object.keys(companyDetails).map((item) => {
            return (
              <div>
                <h3>{camelCaseToWords(item)}</h3>
                <p>{companyDetails[item]}</p>
              </div>
            );
          })
        ) : (
          <> </>
        )}
      </Modal>
    </Fragment>
  );
}
