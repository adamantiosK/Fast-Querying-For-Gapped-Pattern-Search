import "./../App.css";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { Switch, Route, Redirect } from "react-router-dom";
import { Link } from "react-router-dom";

function OldBenchMarks() {
  const [data, setData] = useState([]);

  useEffect(() => {
    // Fetch data from API when component mounts
    fetch("https://localhost:7250/api/BenchMarkController/GetOldBenchMarks")
      .then((response) => response.json())
      .then((data) => setData(data));
  }, []);

  const handleButtonClick = (guid) => {
    // Redirect to details page with GUID parameter in URL
    window.location.href = `/details/${guid}/false`;
  };

  return (
    <div className="App">
      <header className="App-header">
        <div>
          <table>
            <thead>
              <tr>
                <th>
                  <h2>Date &nbsp;</h2>
                </th>
                <th>
                  <h2>|&nbsp;&nbsp;Action</h2>
                </th>
              </tr>
            </thead>
            <tbody>
              {data.map((item) => (
                <tr key={item.guid} >
                  <td>{item.dateTimeResultConducted}</td>
                  <td>
                  &nbsp;
                  &nbsp;
                    <button
                    style={{
                        backgroundColor: "#0070f0",
                        backgroundImage: "linear-gradient(to bottom, #0070f0, #022b59)",
                        borderRadius: "40px",
                        border: "none",
                        color: "#fff",
                        cursor: "pointer",
                        fontSize: "1.1rem",
                        padding: "0.75rem 1.5rem",
                        textDecoration: "none",
                        transition: "background-color 0.3s ease",
                      }}
                    onClick={() => handleButtonClick(item.resultGuid)}>
                      Show Results
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <br/>
          <br/>

          <Link to="/">
            <button
              style={{
                backgroundColor: "#54e867",
                backgroundImage: "linear-gradient(to bottom, #54e867, #38d1cf)",
                borderRadius: "40px",
                border: "none",
                color: "#000",
                cursor: "pointer",
                fontSize: "1.1rem",
                padding: "0.75rem 1.5rem",
                textDecoration: "none",
                transition: "background-color 0.3s ease",
              }}
            >
              Go Back 2 Main Page
            </button>
          </Link>
        </div>
      </header>
    </div>
  );
}

export default OldBenchMarks;
