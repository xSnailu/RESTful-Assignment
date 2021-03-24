import React, { useState, useEffect } from 'react';
import axios from 'axios';

const useSortableData = (items, config = null) => {
  const [sortConfig, setSortConfig] = React.useState(config);

  const sortedItems = React.useMemo(() => {
    let sortableItems = [...items];
    if (sortConfig !== null) {
      sortableItems.sort((a, b) => {
        if (a[sortConfig.key] < b[sortConfig.key]) {
          return sortConfig.direction === 'ascending' ? -1 : 1;
        }
        if (a[sortConfig.key] > b[sortConfig.key]) {
          return sortConfig.direction === 'ascending' ? 1 : -1;
        }
        return 0;
      });
    }
    return sortableItems;
  }, [items, sortConfig]);

  const requestSort = (key) => {
    let direction = 'ascending';
    if (
      sortConfig &&
      sortConfig.key === key &&
      sortConfig.direction === 'ascending'
    ) {
      direction = 'descending';
    }
    setSortConfig({ key, direction });
  };

  return { items: sortedItems, requestSort, sortConfig };
};

const Table = (props) => {
  const { items, requestSort, sortConfig } = useSortableData(props.notes);
  const getClassNamesFor = (title) => {
    if (!sortConfig) {
      return;
    }
    return sortConfig.key === title ? sortConfig.direction : undefined;
  };
  return (
    <table>
      <caption>Notes</caption>
      <thead>
        <tr>
          <th>
            <button
              type="button"
              onClick={() => requestSort('title')}
              className={getClassNamesFor('title')}
            >
              Title
              </button>
          </th>
          <th>
            <button
              type="button"
              onClick={() => requestSort('created')}
              className={getClassNamesFor('created')}
            >
              Created
              </button>
          </th>
          <th>
            <button
              type="button"
              onClick={() => requestSort('modified')}
              className={getClassNamesFor('modified')}
            >
              Modified
              </button>
          </th>
        </tr>
      </thead>
      <tbody>
        {items.map((item) => (
          <tr key={item.id}>
            <td>{item.title}</td>
            <td>{item.created}</td>
            <td>{item.modified}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

function NotesTable(props) {
  const [notes, SetNotes] = useState([]);

  async function fetchData() {
    var config = {
      method: 'get',
      url: 'https://localhost:44398/note/all',
      headers: {
        "Access-Control-Allow-Origin": "*"
      }
    };

    try {
      const response = await axios(config);
      console.log('TEST')
      console.log(response.data)
      SetNotes(response.data);
    }
    catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    fetchData();
  }, []);

  return <Table
    notes={notes}
  />;
}

export default NotesTable
