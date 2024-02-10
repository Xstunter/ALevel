import React from 'react';
import { Box, CssBaseline, Paper, Typography } from '@mui/material';

function App() {
  return (
    <div>
        <CssBaseline/>
          <Box 
            height="100vh"
            display="flex"
            justifyContent="center"
            alignItems="center"
            flexDirection="column"
          >
          <Paper
            elevation={3}
            sx={{padding: "1ren", backgroundColor: "secondary.light"}}
          >
            <Typography color="blue" variant="h1">Starter App</Typography>
          </Paper>
      </Box>
    </div>
  );
}

export default App;
