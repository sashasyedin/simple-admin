import {
    GET_LIST,
    GET_ONE,
    GET_MANY,
    GET_MANY_REFERENCE,
    CREATE,
    UPDATE,
    DELETE,
    fetchUtils,
} from 'react-admin';
import { stringify } from 'query-string';

const API_URL = 'api/v1';

/**
 * @param {String} type One of the constants appearing at the top if this file, e.g. 'UPDATE'
 * @param {String} resource Name of the resource to fetch, e.g. 'posts'
 * @param {Object} params The Data Provider request params, depending on the type
 * @returns {Object} { url, options } The HTTP request parameters
 */
const convertDataProviderRequestToHTTP = (type, resource, params) => {
    switch (type) {
        case GET_LIST: {
            const { page, perPage } = params.pagination;
            const query = {
                filter: JSON.stringify(params.filter),
                pageNumber: page,
                pageSize: perPage
            };
            return { url: `${API_URL}/${resource}?${stringify(query)}` };
        }
        case GET_ONE:
            return { url: `${API_URL}/${resource}/${params.id}` };
        case GET_MANY: {
            return { url: `${API_URL}/${resource}?${params.ids.map(x => "ids=" + x).join("&")}` };
        }
        case GET_MANY_REFERENCE: {
            if (params.target && params.target.subresource) {
                return { url: `${API_URL}/${params.target.resource}/${params.target.resourceId}/${params.target.subresource}` };
            }
            const { page, perPage } = params.pagination;
            const query = {
                filter: JSON.stringify({ ...params.filter, [params.target]: params.id }),
                pageNumber: page,
                pageSize: perPage
            };
            return { url: `${API_URL}/${resource}?${stringify(query)}` };
        }
        case UPDATE:
            return {
                url: `${API_URL}/${resource}/${params.id}`,
                options: { method: 'PUT', body: JSON.stringify(params.data) },
            };
        case CREATE:
            return {
                url: `${API_URL}/${resource}`,
                options: { method: 'POST', body: JSON.stringify(params.data) },
            };
        case DELETE:
            if (params.target && params.target.subresource) {
                return {
                    url: `${API_URL}/${params.target.resource}/${params.target.resourceId}/${params.target.subresource}/${params.target.subresourceId}`,
                    options: { method: 'DELETE' },
                };
            }
            return {
                url: `${API_URL}/${resource}/${params.id}`,
                options: { method: 'DELETE' },
            };
        default:
            throw new Error(`Unsupported fetch action type ${type}`);
    }
};

/**
 * @param {Object} response HTTP response from fetch()
 * @param {String} type One of the constants appearing at the top if this file, e.g. 'UPDATE'
 * @param {String} resource Name of the resource to fetch, e.g. 'posts'
 * @param {Object} params The Data Provider request params, depending on the type
 * @returns {Object} Data Provider response
 */
const convertHTTPResponseToDataProvider = (response, type, resource, params) => {
    const { headers, json } = response;
    switch (type) {
        case GET_LIST:
            return {
                data: json.map(x => x),
                total: parseInt(headers.get('content-range').split('/').pop(), 10),
            };
        case GET_MANY_REFERENCE:
            return {
                data: json.map(x => x),
                total: undefined
            };
        case CREATE:
            return { data: { ...params.data, id: json } };
        case UPDATE: // prevent react-admin from throwing the missing identifier exception
            return { data: { id: undefined } };
        case DELETE:
            return { data: { id: undefined } };
        default:
            return { data: json };
    }
};

/**
 * @param {string} type Request type, e.g GET_LIST
 * @param {string} resource Resource name, e.g. "posts"
 * @param {Object} payload Request parameters. Depends on the request type
 * @returns {Promise} the Promise for response
 */
export default (type, resource, params) => {
    const { fetchJson } = fetchUtils;
    const { url, options } = convertDataProviderRequestToHTTP(type, resource, params);
    return fetchJson(url, options)
        .then(response => convertHTTPResponseToDataProvider(response, type, resource, params));
};