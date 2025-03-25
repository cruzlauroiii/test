import React, { useState } from 'react';
import Search from './components/Search';
import Cart from './components/Cart'
import Payment from './components/Payment'

function App() {

  const products = [
    {id: 1, name: "Chocolate", price: 100}, 
    {id: 2, name: "Candy", price: 200}, 
    {id: 3, name: "Ice Cream", price: 300}, 
  ]


  const [cart, setCart] = useState([])
  const [filteredProducts, setFilteredProducts] = useState(products);


  const handleAddCart = (product, quantity) => {
    const updateCart = [...cart, { ...product, quantity}];
    setCart(updateCart)
  };

  const handleRemoveFromCart = (productId) => {
    const updatedCart = cart.filter((item) => item.id !== productId);
    setCart(updatedCart);
  }

  return (
    <div>
      Sample Screen:<br/>------------------------------------------------------------------------------------------
      
      
      <ol>
        {filteredProducts.map((product, index) => (
        <li key={index}>
          {product.name} - {product.price}
        </li>

        ))}
      </ol>

      <Search products={products}/>
      <Cart cart={cart} handleAddCart={handleAddCart} handleRemoveFromCart={handleRemoveFromCart}/>
      <Payment cart={cart} onTransactionComplete={() => setCart([])} />

    </div>
  );
}

export default App;
