// store.ts
import { configureStore } from '@reduxjs/toolkit';
import counterReducer  from "./counterSlice"
import userReducer from "./userSlice"

export const store = configureStore({
 reducer: {
   counter: counterReducer,
   user:userReducer
 },
});
// Infer RootState and AppDispatch types
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
