import React, { useState, ReactElement, FC, useEffect } from "react";
import { Box, Typography, Button } from "@mui/material";
import { createTheme } from '@mui/material/styles';
import axios from "axios";

const Regres = "https://reqres.in";

const Post: FC<any> = (): ReactElement => {

const [postData, setPostData] = useState({
  name: 'morpheus',
  job: 'leader',
});

const [responseData, setResponseData] = useState(null);

const PostRequest = async () => {
    const response = await axios.post(`${Regres}/api/users`, postData);
    console.log('Data:', response.data);
    setResponseData(response.data);
}

  return (
    <Box
      sx={{
        flexGrow: 1,
        backgroundColor: "whitesmoke",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Button variant="contained" size="large" onClick={PostRequest}>
          Post request
      </Button>
      {responseData && (
        <Typography>
          Data: {JSON.stringify(responseData)}
        </Typography>
      )}
    </Box>
  );
};

export default Post;