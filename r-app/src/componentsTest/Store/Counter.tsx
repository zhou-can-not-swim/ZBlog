// Counter.tsx
import React from 'react';
import { useAppDispatch, useAppSelector } from '../../stores/hooks';
import { decrement, increment, incrementByAmount } from '../../stores/counterSlice';
const Counter = () => {
    const count = useAppSelector((state) => state.counter.value);
    const dispatch = useAppDispatch();


    //  user
    const username = useAppSelector((state) => state.user.username);
    const email = useAppSelector((state) => state.user.email);
    const motto = useAppSelector((state) => state.user.motto);

    return (
        <div>
            <p>{username}</p>
            <p>{email}</p>
            <p>{motto}</p>
            <h1>{count}</h1>
            <button onClick={() => dispatch(increment())}>Increment</button>
            <button onClick={() => dispatch(decrement())}>Decrement</button>
            <button onClick={() => dispatch(incrementByAmount(5))}>Add 5</button>
        </div>
    );
};
export default Counter;