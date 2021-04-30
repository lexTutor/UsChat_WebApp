import styled from "styled-components";

// Styled component named StyledButton
export default styled.div`
  font-size: 12px;
  color: ${props => (props.main === 1 ? "black" : "#fff")};
  background-color: ${props => (props.main === 1 ? "#f1f1f1" : " #1f2667bf")};
border-radius:9px;
padding: 10px;
margin:10px;
  text-align: ${props => (props.main === 1? "right": "left")};
`;

//  margin-left: ${props => (props.margin * 10).toString() + "px"};
