import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface AdminState {
    password: string;
}

export class Admin extends React.Component<RouteComponentProps<{}>, AdminState> {
    constructor() {
        super();
        this.state = { password: "" };
    }

    public render() {
        return <div>
            <h1>Update weather</h1>

            <form onSubmit={(e) => this.handleSubmit(e)}>
                <label>
                    Administrator password:
                <input type="password" value={this.state.password} onChange={(e) => this.handleChange(e)} />
                </label>
                <input type="submit" value="Update" />
            </form>
        </div>;
    }

    handleSubmit(e) {
        e.preventDefault();
        var data = this.state;
        this.setState({
            password: ""
        });

        fetch('api/weather/update',
            {
                method: 'POST', // or 'PUT'
                body: JSON.stringify(data), // data can be `string` or {object}!
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {

                if (response.ok) {
                    alert("Successfully updated weather.");
                }
                else {
                    alert("Invalid password!");
                }
            });
             
           
    }
    handleChange(e) {
        this.setState({
            password: e.target.value
        })
    }
}
