import React from 'react';

function Cart({ cart, handleRemoveFromCart }) {
    const calculateTotal = () => {
        return cart.reduce((acc, item) => acc + item.price * item.quantity, 0);
    };

    return (
        <div>
            Ordered List<br/>
            <table border="1">
                <thead>
                    <th>Product Name</th>
                    <th>Cost</th>
                    <th>Qty</th>
                    <th>Amount</th>
                    <th>Action</th>
                </thead>
            
            {cart.length === 0 ? (
                <p>cart is empty</p>

            ) : (
                <ol>
                    {cart.map((item) => (
                        <li key={item.id}>
                            {item.name} - {item.quantity} x ${item.price}
                            <td>
                                <button onClick={()=>handleRemoveFromCart(item.id)}>
                                    Remove
                                </button>
                            </td>
                            
                        </li>
                    ))}
                </ol>
            )}
            </table>
            Total: ${calculateTotal()}
        </div>
    );
}

export default Cart;