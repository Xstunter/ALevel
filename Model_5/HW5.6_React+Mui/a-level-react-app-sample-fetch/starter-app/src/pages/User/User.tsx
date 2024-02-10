import React, {ReactElement, FC, useEffect, useState} from "react";
import {
    Box,
    Table, TableContainer, TableHead, Typography, TableRow, TableCell, TableBody
} from '@mui/material'
import {IUser} from "../../models/user.model";
import axios from "axios";
import { IUserRegresResponce } from "../../models/user.regres-responce";

const User: FC<any> = (): ReactElement => {

    const [user, setUser] = useState<IUserRegresResponce | null>(null)

    const Regres = "https://reqres.in";

    useEffect(() => {
        axios.get<IUserRegresResponce>(`${Regres}/api/users/2`)
        .then(response => { 
            console.log(response);
            setUser(response.data)
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

{user && 
              <TableContainer>
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell align="center">ID</TableCell>
                      <TableCell align="center">Name</TableCell>
                      <TableCell align="center">Surname</TableCell>
                      <TableCell align="center">Email</TableCell>
                      <TableCell align="center">Avatar</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    <TableRow 
                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                    >
                      <TableCell align="center">{user.data.id}</TableCell>
                      <TableCell align="center">{user.data.first_name}</TableCell>
                      <TableCell align="center">{user.data.last_name}</TableCell>
                      <TableCell align="center">{user.data.email}</TableCell>
                      <TableCell align="center">{user.data.avatar}</TableCell>
                    </TableRow>
                  </TableBody>
                </Table>
              </TableContainer>
      } 


    </Box>
    );
};

export default User;