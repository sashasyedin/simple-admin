import React from 'react';
import {
    Show,
    List,
    Edit,
    SimpleShowLayout,
    TextField,
    Datagrid,
    ShowButton,
    TabbedForm,
    FormTab,
    TextInput
} from 'react-admin';

const UserTitle = ({ record }) => {
    return <span>User {record ? `"${record.mode}"` : ''}</span>;
};

export const UserShow = (props) => {
    return (
        <Show title={<UserTitle />} {...props}>
            <SimpleShowLayout>
                <TextField label="Id" source="id" />
                <TextField label="Name" source="name" />
            </SimpleShowLayout>
        </Show>
    );
};

export const UserList = (props) => {
    return (
        <List title="Users" {...props}>
            <Datagrid>
                <TextField source="name" sortable={false} />
                <ShowButton />
            </Datagrid>
        </List>
    );
};

export const UserEdit = (props) => {
    return (
        <Edit title={<UserTitle />} {...props}>
            <TabbedForm>
                <FormTab label="Basic">
                    <TextInput label="Name" source="name" />
                </FormTab>
                <FormTab label="Additional Info">
                </FormTab>
            </TabbedForm>
        </Edit>
    );
};