import "./../App.css";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { Switch, Route, Redirect } from "react-router-dom";
import { Link } from 'react-router-dom';

function MainPage() {
  const [guid, setGuid] = useState(null);
  const [status, setStatus] = useState(null);

  const handleClick = async () => {
    try {
      const response = await fetch(
        "https://localhost:7250/api/BenchMarkController/NewReportStatusGuid"
      );
      if (!response.ok) {
        throw new Error("Failed to generate GUID");
      }
      const data = await response.json();

      setGuid(data);
      const reportResponse = await axios.post(
        `https://localhost:7250/api/BenchMarkController/RunBenchMarksForAvailableAlgorithms/${data}`
      );
      const reportData = await reportResponse.json();

      console.log(reportData);
      // process reportData as needed
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    // Set up an interval that runs every 10 seconds
    const intervalId = setInterval(async () => {
      // Check if a GUID has been generated yet
      if (guid) {
        // If so, send a GET request to the API to check the status of the request
        const response = await axios.get(
          `https://localhost:7250/api/BenchMarkController/GetReportProgressFromIdentifier/${guid}`
        );
        // Update the status state variable with the status returned by the API
        setStatus(response.data.progressStatus);
        if (response.data.reportCompleted) {
          setGuid(null);
          setStatus(null);
        }
      }
    }, 2000);

    // Clean up the interval when the component unmounts or when the GUID changes
    return () => clearInterval(intervalId);
  }, [guid]);

  return (
    <div className="App">
      <header className="App-header">
        {/* <img src={logo} className="App-logo" alt="logo" /> */}
        <header
          style={{
            borderBottom: "1px solid #00CCCC",
            padding: "1rem",
            marginBottom: "2rem",
          }}
        >
          {status && (
            <h1
              style={{
                fontSize: "1.8rem",
                fontWeight: "bold",
                margin: 0,
                color: "#00CCCC",
                textShadow: "1px 1px #fff",
              }}
            >
              Benchmark status: {status}
            </h1>
          )}
          {!status && (
            <h1
              style={{
                fontSize: "1.8rem",
                fontWeight: "bold",
                margin: 0,
                color: "#00CCCC",
                textShadow: "1px 1px #fff",
              }}
            >
              Fast Searching for Gapped Pattern Matching
            </h1>
          )}
        </header>
        <div style={{ display: "flex", gap: "10px" }}>
          <button
            style={{
              backgroundColor: "#0077cc",
              backgroundImage: "linear-gradient(to bottom, #00CCCC, #005da3)",
              borderRadius: "40px",
              border: "none",
              color: "#fff",
              cursor: "pointer",
              fontSize: "1.1rem",
              padding: "0.75rem 1.5rem",
              textDecoration: "none",
              transition: "background-color 0.3s ease",
            }}
            disabled={guid !== null}
            onClick={handleClick}
          >
            Run new Benchmarks
          </button>
          <Link to="/old-benchmarks">
            <button
              style={{
                backgroundColor: "#ba862b",
                backgroundImage: "linear-gradient(to bottom, #ba862b, #afc223)",
                borderRadius: "40px",
                border: "none",
                color: "#00000",
                cursor: "pointer",
                fontSize: "1.1rem",
                padding: "0.75rem 1.5rem",
                textDecoration: "none",
                transition: "background-color 0.3s ease",
              }}
            >
              Browse Old BenchMarks
            </button>
          </Link>
        </div>
      </header>
    </div>
  );
}

export default MainPage;