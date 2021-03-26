import logo from './logo.svg';
import './App.css';
import React from 'react';
import NotesTable from './components/NotesTable';


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <NotesTable></NotesTable>
      </header>
    </div>
  );
}

export default App;
