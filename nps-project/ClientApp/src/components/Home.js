import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div>
            <h1>Welcome to the nps filtering project.</h1>

            <p>This Project is to demostrate a .net application which uses C# web API in
                the back end getting information from the NPS API and uses react in the front end to display the information.</p>

            <p>the parks page will display the table with all of the park information for parks in PA, DE, NJ, and NY with a biking activity.
                The parks filtered page will show a similar table but allows you to filter the information using a dropdown for you to select the state you
                would like view.</p>
      </div>
    );
  }
}
