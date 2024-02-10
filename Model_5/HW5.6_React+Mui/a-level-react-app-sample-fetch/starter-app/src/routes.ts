// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Products";
import User from "./pages/User";
import Post from "./pages/Post"

// other
import {FC} from "react";

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        component: About
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        component: Products
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: true,
        component: User
    },
    {
        key: 'post-route',
        title: 'Post',
        path: '/post/:id',
        enabled: true,
        component: Post
    }
]