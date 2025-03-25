import React, {useState} from "react";

function Payment({ cart, onTransactionComplete}) {
    const [cash, setCash] = useState(0);
    const [change, setChange] = useState(0);
    const totalAmount = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);

    const handlePayment = () => {
        if (cash >= totalAmount) {
            setChange(cash - totalAmount);
            onTransactionComplete();
        } else {
            alert("Insufficient funds");
        }
    }

    return (
        <div>

            Total Amount: <input value={totalAmount}/><br/>
            Cash: <input type="number"
                        value={cash}
                        onChange={(e) => setCash(Number(e.target.value))}
                        /><br/>
            Change: <input value={change}/><br/>
            <button onClick={handlePayment}>Save Transaction</button>

        </div>
    )
}

export default Payment;