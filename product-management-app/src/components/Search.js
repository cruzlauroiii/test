import React, {useState} from "react";

function Search({ products }) {
    const [searchId, setSearchId] = useState("");
    const [searchedProduct, setSearchedProduct] = useState(null);
`
    const handleSearch = (e) => {`
        console.log(products)
        const product = products.find((prod) => prod.id.toString() === searchId)
        setSearchedProduct(product || null)
    };

    return (
        <div>
            Search Product ID: <input
                type="text"
                value={searchId}
                onChange={(e) => setSearchId(e.target.value)}
                /> <button onClick={handleSearch}>Search Button</button>

            {searchedProduct ? (
                <div>
                    Product ID: <input value={searchedProduct.id}/>
                    Name: <input value={searchedProduct.name}/>
                    Cost: <input value={searchedProduct.price}/>
                    <button>Add to Cart</button>
                    
                </div>
            ) : (searchId && <p></p>)}

        </div>
    )
}

export default Search;