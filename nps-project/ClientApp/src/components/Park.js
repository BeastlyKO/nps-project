import React, { Component } from 'react';

export class Park extends Component {

    constructor(props) {
        super(props);
        this.state = { parks: [], loading: true }
    }

 

    componentDidMount() {
        this.PopulateTable();
    }

    static renderParkTable(parks) {
        return (

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Park Name</th>
                        <th>Park Code</th>
                        <th>States</th>
                        <th>Address</th>
                        
                    </tr>
                </thead>
                <tbody>
                    {parks.map(park =>
                        <tr>
                            <td>{park.name}</td>
                            <td>{park.parkCode}</td>
                            <td>{park.states}</td>
                            <td>{park.addresses[0].line1 + ", "
                                + park.addresses[0].city + ", "
                                + park.addresses[0].stateCode + " "
                                + park.addresses[0].postalCode}</td>

                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Park.renderParkTable(this.state.parks);

        return (
            <div>
                <h1 id="tabelLabel" >Parks with Biking Activity</h1>
                <p>Here is a list of all the parks between PA, NJ, DE, and NY with a biking activity.</p>
                {contents}
            </div>
        );
    }

    async PopulateTable() {
        const response = await fetch('park');
        const data = await response.json();
        this.setState({ parks: data, loading: false })

    }
}
