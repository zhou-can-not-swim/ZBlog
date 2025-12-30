// counterSlice.ts
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
interface UserState {
 username:string,
 motto:string,
 email:string,
}
const initialState: UserState = { 
     username:"张三",
    motto:"hhxx",
    email:"admin@example.com",
};

const userSlice = createSlice({
 name: 'user',
 initialState,
 reducers: {
   setUserName: (state,action) => {
     state.username =action.payload;
   },
   setMotto: (state,action) => {
     state.motto =action.payload;
   },
   setEmail: (state,action) => {
     state.email =action.payload;
   },
 },
});
export const { setUserName, setMotto, setEmail } = userSlice.actions;
export default userSlice.reducer;