import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    forecasts: any;
    loading: boolean;
}

export class Weather extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { forecasts: [], loading: true };

        fetch('api/weather')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Weather.renderForecastsTable(this.state.forecasts);

        return <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>;
    }

    private static renderForecastsTable(forecasts: any) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>City</th>
                    <th>Temp. (C)</th>
                    <th>Humidity(%)</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.id}>
                        <td>{forecast.cityName}</td>
                        <td>{forecast.temperature}</td>
                        <td>{forecast.humidity}</td>
                        <td>{forecast.name}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
