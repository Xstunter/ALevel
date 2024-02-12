import React, { ReactElement, FC, useEffect, useState } from "react";
import { IResourceRegresResponce } from "../../models/resource.regres-responce";
import { Box, Stack, Table, TableContainer, TableHead, Typography, TableRow, TableCell, TableBody } from "@mui/material";
import axios from "axios";

const Regres = "https://reqres.in";

const Products: FC<any> = (): ReactElement => {
  
  const [regresResponce, setRegresResponce] = useState<IResourceRegresResponce | null>(null)

  useEffect(() => {
    axios.get<IResourceRegresResponce>(`${Regres}/api/unknown/5`)
         .then(response => { 
          console.log(response);
          setRegresResponce(response.data)
          });
  }, [])

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
      {regresResponce && 
              <TableContainer >
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="center">ID</TableCell>
                      <TableCell align="center">Name</TableCell>
                      <TableCell align="center">Year</TableCell>
                      <TableCell align="center">Color</TableCell>
                      <TableCell align="center">Phone-value</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    <TableRow 
                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                    >
                      <TableCell align="center">{regresResponce.data.id}</TableCell>
                      <TableCell align="center">{regresResponce.data.name}</TableCell>
                      <TableCell align="center">{regresResponce.data.year}</TableCell>
                      <TableCell align="center">{regresResponce.data.color}</TableCell>
                      <TableCell align="center">{regresResponce.data.pantone_value}</TableCell>
                    </TableRow>
                  </TableBody>
                </Table>
              </TableContainer>
      } 
    </Box>
  );
};

export default Products;