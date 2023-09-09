// Import React
import React from "react";

// Import Bootstrap
import { Nav, Navbar, Container, Row, Col }
  from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.css";

// Import Custom CSS
import "./App.css";

// Import from react-router-dom
import {
  BrowserRouter as Router, Routes,
  Route, Link, useParams,
} from "react-router-dom";

// Import other React Component

import CityFind from "./Components/city-find";
import TopSearches from "./Components/top-searches";
import ZipCodeFind from "./Components/code-find";

// App Component
const App = () => {
  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <Navbar bg="dark" variant="dark">
            <Container>
              <Navbar.Brand>
                <Link to={"/top-searches"}
                  className="nav-link">
                 Zip Code finder app
                </Link>
              </Navbar.Brand>

              <Nav className="justify-content-end">
                <Nav>
                  <Link to={"/find-city"}
                    className="nav-link">
                   Find City
                  </Link>
                </Nav>

                <Nav>
                  <Link to={"/find-code"}
                    className="nav-link">
                    Find Zip Code
                  </Link>
                </Nav>

                <Nav>
                  <Link to={"/top-searches"}
                    className="nav-link">
                    Top Searches
                  </Link>
                </Nav>


              </Nav>
            </Container>
          </Navbar>
        </header>

        <Container>
          <Row>
            <Col md={12}>
              <div className="wrapper">
                <Routes>
                  <Route exact path="/welcome"
                    element={<CityFind />} />
                  <Route path="/top-searches"
                    element={<TopSearches/>} />   
                  <Route exact path="/find-city"
                    element={<CityFind />} /> 
                     <Route exact path="/find-code"
                    element={<ZipCodeFind />} /> 
                </Routes>
              </div>
            </Col>
          </Row>
        </Container>
      </div>
    </Router>
  );
};

export default App;
