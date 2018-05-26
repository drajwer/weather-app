import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Weather } from './components/Weather';
import { Admin } from './components/Admin';

export const routes = <Layout>
    <Route exact path='/' component={Weather } />
    <Route path='/admin' component={ Admin } />
</Layout>;
