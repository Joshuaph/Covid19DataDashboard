import React, {Component} from 'react';
import {Badge, Container, ListGroup, ListGroupItem, Spinner} from 'reactstrap';

export class CurrentUS extends Component {
    static displayName = CurrentUS.name;

    constructor(props) {
        super(props);
        this.state = {
            CurrentUS: [],
            loading: true
        };
    }

    componentDidMount() {
        this.populateCurrentUSData();
    }

    renderData = (data) => {
        
        let date = (data.date).toString()
        let year = date.substring(0,4);
        let month = date.substring(4,6);
        let day = date.substring(6,8);
        let dateStr = `${month}/${day}/${year}`;
        
        return (
            <Container>
                <ListGroup>
                    <ListGroupItem>Date of Data: <Badge pill>{dateStr}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number of Positive Cases: <Badge pill>{(data.positive).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number of Pending Tests: <Badge pill>{(data.pending).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number People in the Hospital: <Badge pill>{(data.hospitalizedCurrently).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number People in the ICU: <Badge pill>{(data.inIcuCurrently).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number People on a ventilator: <Badge pill>{(data.onVentilatorCurrently).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Current Number People who've recovered from Covid19: <Badge pill>{(data.recovered).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>Total Number of Deaths: <Badge pill>{(data.death).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>New Deaths: <Badge pill>{(data.deathIncrease).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>New Cases: <Badge pill>{(data.positiveIncrease).toLocaleString('en')}</Badge></ListGroupItem>
                    <ListGroupItem>New hospitalizations: <Badge pill>{(data.hospitalizedIncrease).toLocaleString('en')}</Badge></ListGroupItem>
                </ListGroup>
            </Container>
        );
    }
    
    render() {
        let content = this.state.loading
            ? <Spinner color="primary"/>
            : this.renderData(this.state.CurrentUS);

        return (
            <div>
                {content}
            </div>
        );
    }



    async populateCurrentUSData() {
        const response = await fetch('Covid19/GetUsCurrent');
        const data = await response.json();
        this.setState({CurrentUS: data, loading: false});
    }
}
