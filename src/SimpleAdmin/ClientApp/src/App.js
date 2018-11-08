import React from 'react';
import { Admin, Resource } from 'react-admin';

import dataProvider from './dataProvider';
import dashboard from './dashboard';
import { UserShow, UserEdit, UserList } from './resources/users/index'

const App = () => (
    <Admin dashboard={dashboard} dataProvider={dataProvider} title="RP16 Administration">
        <Resource name="users" show={UserShow} list={UserList} edit={UserEdit} options={{ label: 'Available Users' }} />
    </Admin>
);

export default App;