// src/CarsTable.jsx
import { useEffect, useState } from 'react';
import axios from 'axios';

const CarsTable = () => {
    const [cars, setCars] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('http://localhost:5091/api/CarsData/GetCarsFromMemory');
                setCars(Array.isArray(response.data) ? response.data : []);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div>
            <h1>Cars List</h1>
            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Mileage</th>
                        <th>Make</th>
                        <th>Model</th>
                        <th>Fuel</th>
                        <th>Gear</th>
                        <th>Offer Type</th>
                        <th>Hp</th>
                        <th>Year</th>
                    </tr>
                </thead>
                <tbody>
                    {cars.map(cars => (
                        <tr key={cars.id}>
                            <td>{cars.id}</td>
                            <td>{cars.mileage}</td>
                            <td>{cars.make}</td>
                            <td>{cars.model}</td>
                            <td>{cars.fuel}</td>
                            <td>{cars.gear}</td>
                            <td>{cars.offer}</td>
                            <td>{cars.hp}</td>
                            <td>{cars.year}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default CarsTable;