import React, { Component } from 'react';


export class ParkFilter extends Component {

    constructor(props) {
        super(props);
        this.state = { parks: [], loading: true, value: "All" }
        this.handleChange = this.handleChange.bind(this);
        
    }
    

    componentDidMount() {
        this.PopulateTable();
    }

    componentDidUpdate(prevProps, prevState) {
        if (prevState.value != this.state.value) {
            if (this.state.value == -1) {
                this.PopulateTable();
            }
            else {
                this.PopulateFilteredTable(this.state.value);
            }
        }
    }


    handleChange(event) {

        this.setState({ parks: [], value: event.target.value, loading: true })
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
                                + park.addresses[0].postalCode}
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {

      
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ParkFilter.renderParkTable(this.state.parks);

        return (
            <div>
                <h1 id="tabelLabel" >Parks with Biking Activity</h1>
                <p>Here is a list of all the parks between PA, NJ, DE, and NY with a biking activity. The State Filter can be used to filter the data.</p>
                <p>Note: The table will take a moment to load when filtering.</p>

                <label>
                    State Filter: 
                    <select onChange={this.handleChange}>
                        <option value="ALL">All</option>
                        <option value="DE">DE</option>
                        <option value="NJ">NJ</option>
                        <option value="NY">NY</option>
                        <option value="PA">PA</option>
                    </select>
                </label>
          
                {contents}
            </div>
        );
    }

    async PopulateTable() {
        const response = await fetch('park');
        const data = await response.json();
        this.setState({ parks: data, loading: false })

    }

    async PopulateFilteredTable(id) {       
        const response = await fetch('park/' + id);
        const data = await response.json();
        this.setState({ parks: data, loading: false })
   }
}
