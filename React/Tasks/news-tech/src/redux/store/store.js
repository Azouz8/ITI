import { configureStore } from "@reduxjs/toolkit";
import LangR from '../slices/langSlice'
import ThemeR from '../slices/themeSlice'
import PostsR from '../slices/postsSlice'

export let storeConfig = configureStore({
    reducer: {
        postsR: PostsR,
        langR: LangR,
        themeR: ThemeR,
    }
})