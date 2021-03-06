import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      username: '',
      isCompleted: ''
    };
  }

  mySubmitHandler(event) {
    const { username, isCompleted } = this.state;
    const reqParams = { "name": username, "isComplete": isCompleted }
    event.preventDefault();

    fetch('https://hc-netcore.azurewebsites.net/api/TodoItems', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(reqParams),
    }
    )
      .then(response => response.json())
      .then((data) => {
        console.log('data : ', data);

      })
      .catch((e) => {
        console.log('error : ', e);

      })
  }

  myChangeHandler = (event) => {
    this.setState({ username: event.target.value });
  }

  isCompleteHandler = (event) => {
    this.setState({ isCompleted: event.target.value });
  }

  render() {
    return (
      <div>
        <form onSubmit={(event) => this.mySubmitHandler(event)}>
          <h1>HarvestCraft Payments</h1>
          <div className="form-group">
            <p>Name</p>
            <input
              className="form-control"
              type='text'
              onChange={this.myChangeHandler}
            />
          </div>

          <div className="form-group">
            <p>isCompleted</p>
            <input
              className="form-control"
              type='text'
              onChange={this.isCompleteHandler}
            />
          </div>

          <input
            className="form-control btn-primary"
            type='submit'
          />

        </form>

      </div>
    );
  }
}