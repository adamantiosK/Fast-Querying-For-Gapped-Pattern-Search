import React, { useState, useEffect } from "react";
import axios from "axios";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";

function DynamicTable() {
  const { guid } = useParams(); // Get guid from URL params
  const { bool } = useParams();
  const [data, setData] = useState([]);

  useEffect(() => {
    // Fetch data from API when component mounts
    axios.get(`https://localhost:7250/api/BenchMarkController/GetReportProgressFromIdentifier/Results/${guid}/${bool}`)
      .then(response => {
        setData(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, [guid]);

  // Determine the number of columns based on the first row of data
  const numColumns = data.length > 0 ? data[0].length : 0;

  return (
    <div className="App">
      <header className="App-header">
        <div>
      <table>
        <thead>
          <tr>
            {[...Array(numColumns)].map((_, index) => (
              <th key={index}></th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, index) => (
            <tr key={index}>
              {row.map((cell, index) => (
                <td key={index} className="cell">{cell}</td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
      <br/>
          <br/>

          <Link to="/old-benchmarks">
            <button
              style={{
                backgroundColor: "#9445d1",
                backgroundImage: "linear-gradient(to bottom, #9445d1, #9c3086)",
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
              Go Back 2 BenchMark History
            </button>
          </Link>
        </div>
      </header>
    </div>
  );
}

export default DynamicTable;
