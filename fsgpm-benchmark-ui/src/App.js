import React, { useState, useEffect } from "react";
import MainPage from "./components/MainPage";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import OldBenchMarks from "./components/OldBenchMarks";
import DynamicTable from "./components/Results";


function App() {
  return (
    <Router>
        <Routes>
          <Route exact path="/" element={<MainPage/>}/>
          <Route exact path="/old-benchmarks" element={<OldBenchMarks/>}/>
          <Route exact path="/details/:guid/:bool" element={<DynamicTable />} />
        </Routes>
    </Router>
  );
}

export default App;

