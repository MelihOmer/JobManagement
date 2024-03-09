(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["signalR"] = factory();
	else
		root["signalR"] = factory();
})(self, function() {
return /******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	// The require scope
/******/ 	var __webpack_require__ = {};
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/global */
/******/ 	(() => {
/******/ 		__webpack_require__.g = (function() {
/******/ 			if (typeof globalThis === 'object') return globalThis;
/******/ 			try {
/******/ 				return this || new Function('return this')();
/******/ 			} catch (e) {
/******/ 				if (typeof window === 'object') return window;
/******/ 			}
/******/ 		})();
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// ESM COMPAT FLAG
__webpack_require__.r(__webpack_exports__);

// EXPORTS
__webpack_require__.d(__webpack_exports__, {
  "AbortError": () => (/* reexport */ AbortError),
  "DefaultHttpClient": () => (/* reexport */ DefaultHttpClient),
  "HttpClient": () => (/* reexport */ HttpClient),
  "HttpError": () => (/* reexport */ HttpError),
  "HttpResponse": () => (/* reexport */ HttpResponse),
  "HttpTransportType": () => (/* reexport */ HttpTransportType),
  "HubConnection": () => (/* reexport */ HubConnection),
  "HubConnectionBuilder": () => (/* reexport */ HubConnectionBuilder),
  "HubConnectionState": () => (/* reexport */ HubConnectionState),
  "JsonHubProtocol": () => (/* reexport */ JsonHubProtocol),
  "LogLevel": () => (/* reexport */ LogLevel),
  "MessageType": () => (/* reexport */ MessageType),
  "NullLogger": () => (/* reexport */ NullLogger),
  "Subject": () => (/* reexport */ Subject),
  "TimeoutError": () => (/* reexport */ TimeoutError),
  "TransferFormat": () => (/* reexport */ TransferFormat),
  "VERSION": () => (/* reexport */ VERSION)
});

;// CONCATENATED MODULE: ./src/Errors.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
/** Error thrown when an HTTP request fails. */
class HttpError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.HttpError}.
     *
     * @param {string} errorMessage A descriptive error message.
     * @param {number} statusCode The HTTP status code represented by this error.
     */
    constructor(errorMessage, statusCode) {
        const trueProto = new.target.prototype;
        super(`${errorMessage}: Status code '${statusCode}'`);
        this.statusCode = statusCode;
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when a timeout elapses. */
class TimeoutError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.TimeoutError}.
     *
     * @param {string} errorMessage A descriptive error message.
     */
    constructor(errorMessage = "A timeout occurred.") {
        const trueProto = new.target.prototype;
        super(errorMessage);
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when an action is aborted. */
class AbortError extends Error {
    /** Constructs a new instance of {@link AbortError}.
     *
     * @param {string} errorMessage A descriptive error message.
     */
    constructor(errorMessage = "An abort occurred.") {
        const trueProto = new.target.prototype;
        super(errorMessage);
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when the selected transport is unsupported by the browser. */
/** @private */
class UnsupportedTransportError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.UnsupportedTransportError}.
     *
     * @param {string} message A descriptive error message.
     * @param {HttpTransportType} transport The {@link @microsoft/signalr.HttpTransportType} this error occured on.
     */
    constructor(message, transport) {
        const trueProto = new.target.prototype;
        super(message);
        this.transport = transport;
        this.errorType = 'UnsupportedTransportError';
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when the selected transport is disabled by the browser. */
/** @private */
class DisabledTransportError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.DisabledTransportError}.
     *
     * @param {string} message A descriptive error message.
     * @param {HttpTransportType} transport The {@link @microsoft/signalr.HttpTransportType} this error occured on.
     */
    constructor(message, transport) {
        const trueProto = new.target.prototype;
        super(message);
        this.transport = transport;
        this.errorType = 'DisabledTransportError';
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when the selected transport cannot be started. */
/** @private */
class FailedToStartTransportError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.FailedToStartTransportError}.
     *
     * @param {string} message A descriptive error message.
     * @param {HttpTransportType} transport The {@link @microsoft/signalr.HttpTransportType} this error occured on.
     */
    constructor(message, transport) {
        const trueProto = new.target.prototype;
        super(message);
        this.transport = transport;
        this.errorType = 'FailedToStartTransportError';
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when the negotiation with the server failed to complete. */
/** @private */
class FailedToNegotiateWithServerError extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.FailedToNegotiateWithServerError}.
     *
     * @param {string} message A descriptive error message.
     */
    constructor(message) {
        const trueProto = new.target.prototype;
        super(message);
        this.errorType = 'FailedToNegotiateWithServerError';
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}
/** Error thrown when multiple errors have occured. */
/** @private */
class AggregateErrors extends Error {
    /** Constructs a new instance of {@link @microsoft/signalr.AggregateErrors}.
     *
     * @param {string} message A descriptive error message.
     * @param {Error[]} innerErrors The collection of errors this error is aggregating.
     */
    constructor(message, innerErrors) {
        const trueProto = new.target.prototype;
        super(message);
        this.innerErrors = innerErrors;
        // Workaround issue in Typescript compiler
        // https://github.com/Microsoft/TypeScript/issues/13965#issuecomment-278570200
        this.__proto__ = trueProto;
    }
}

;// CONCATENATED MODULE: ./src/HttpClient.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
/** Represents an HTTP response. */
class HttpResponse {
    constructor(statusCode, statusText, content) {
        this.statusCode = statusCode;
        this.statusText = statusText;
        this.content = content;
    }
}
/** Abstraction over an HTTP client.
 *
 * This class provides an abstraction over an HTTP client so that a different implementation can be provided on different platforms.
 */
class HttpClient {
    get(url, options) {
        return this.send({
            ...options,
            method: "GET",
            url,
        });
    }
    post(url, options) {
        return this.send({
            ...options,
            method: "POST",
            url,
        });
    }
    delete(url, options) {
        return this.send({
            ...options,
            method: "DELETE",
            url,
        });
    }
    /** Gets all cookies that apply to the specified URL.
     *
     * @param url The URL that the cookies are valid for.
     * @returns {string} A string containing all the key-value cookie pairs for the specified URL.
     */
    // @ts-ignore
    getCookieString(url) {
        return "";
    }
}

;// CONCATENATED MODULE: ./src/ILogger.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// These values are designed to match the ASP.NET Log Levels since that's the pattern we're emulating here.
/** Indicates the severity of a log message.
 *
 * Log Levels are ordered in increasing severity. So `Debug` is more severe than `Trace`, etc.
 */
var LogLevel;
(function (LogLevel) {
    /** Log level for very low severity diagnostic messages. */
    LogLevel[LogLevel["Trace"] = 0] = "Trace";
    /** Log level for low severity diagnostic messages. */
    LogLevel[LogLevel["Debug"] = 1] = "Debug";
    /** Log level for informational diagnostic messages. */
    LogLevel[LogLevel["Information"] = 2] = "Information";
    /** Log level for diagnostic messages that indicate a non-fatal problem. */
    LogLevel[LogLevel["Warning"] = 3] = "Warning";
    /** Log level for diagnostic messages that indicate a failure in the current operation. */
    LogLevel[LogLevel["Error"] = 4] = "Error";
    /** Log level for diagnostic messages that indicate a failure that will terminate the entire application. */
    LogLevel[LogLevel["Critical"] = 5] = "Critical";
    /** The highest possible log level. Used when configuring logging to indicate that no log messages should be emitted. */
    LogLevel[LogLevel["None"] = 6] = "None";
})(LogLevel || (LogLevel = {}));

;// CONCATENATED MODULE: ./src/Loggers.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
/** A logger that does nothing when log messages are sent to it. */
class NullLogger {
    constructor() { }
    /** @inheritDoc */
    // eslint-disable-next-line
    log(_logLevel, _message) {
    }
}
/** The singleton instance of the {@link @microsoft/signalr.NullLogger}. */
NullLogger.instance = new NullLogger();

;// CONCATENATED MODULE: ./src/Utils.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


// Version token that will be replaced by the prepack command
/** The version of the SignalR client. */
const VERSION = "6.0.6";
/** @private */
class Arg {
    static isRequired(val, name) {
        if (val === null || val === undefined) {
            throw new Error(`The '${name}' argument is required.`);
        }
    }
    static isNotEmpty(val, name) {
        if (!val || val.match(/^\s*$/)) {
            throw new Error(`The '${name}' argument should not be empty.`);
        }
    }
    static isIn(val, values, name) {
        // TypeScript enums have keys for **both** the name and the value of each enum member on the type itself.
        if (!(val in values)) {
            throw new Error(`Unknown ${name} value: ${val}.`);
        }
    }
}
/** @private */
class Platform {
    // react-native has a window but no document so we should check both
    static get isBrowser() {
        return typeof window === "object" && typeof window.document === "object";
    }
    // WebWorkers don't have a window object so the isBrowser check would fail
    static get isWebWorker() {
        return typeof self === "object" && "importScripts" in self;
    }
    // react-native has a window but no document
    static get isReactNative() {
        return typeof window === "object" && typeof window.document === "undefined";
    }
    // Node apps shouldn't have a window object, but WebWorkers don't either
    // so we need to check for both WebWorker and window
    static get isNode() {
        return !this.isBrowser && !this.isWebWorker && !this.isReactNative;
    }
}
/** @private */
function getDataDetail(data, includeContent) {
    let detail = "";
    if (isArrayBuffer(data)) {
        detail = `Binary data of length ${data.byteLength}`;
        if (includeContent) {
            detail += `. Content: '${formatArrayBuffer(data)}'`;
        }
    }
    else if (typeof data === "string") {
        detail = `String data of length ${data.length}`;
        if (includeContent) {
            detail += `. Content: '${data}'`;
        }
    }
    return detail;
}
/** @private */
function formatArrayBuffer(data) {
    const view = new Uint8Array(data);
    // Uint8Array.map only supports returning another Uint8Array?
    let str = "";
    view.forEach((num) => {
        const pad = num < 16 ? "0" : "";
        str += `0x${pad}${num.toString(16)} `;
    });
    // Trim of trailing space.
    return str.substr(0, str.length - 1);
}
// Also in signalr-protocol-msgpack/Utils.ts
/** @private */
function isArrayBuffer(val) {
    return val && typeof ArrayBuffer !== "undefined" &&
        (val instanceof ArrayBuffer ||
            // Sometimes we get an ArrayBuffer that doesn't satisfy instanceof
            (val.constructor && val.constructor.name === "ArrayBuffer"));
}
/** @private */
async function sendMessage(logger, transportName, httpClient, url, accessTokenFactory, content, options) {
    let headers = {};
    if (accessTokenFactory) {
        const token = await accessTokenFactory();
        if (token) {
            headers = {
                ["Authorization"]: `Bearer ${token}`,
            };
        }
    }
    const [name, value] = getUserAgentHeader();
    headers[name] = value;
    logger.log(LogLevel.Trace, `(${transportName} transport) sending data. ${getDataDetail(content, options.logMessageContent)}.`);
    const responseType = isArrayBuffer(content) ? "arraybuffer" : "text";
    const response = await httpClient.post(url, {
        content,
        headers: { ...headers, ...options.headers },
        responseType,
        timeout: options.timeout,
        withCredentials: options.withCredentials,
    });
    logger.log(LogLevel.Trace, `(${transportName} transport) request complete. Response status: ${response.statusCode}.`);
}
/** @private */
function createLogger(logger) {
    if (logger === undefined) {
        return new ConsoleLogger(LogLevel.Information);
    }
    if (logger === null) {
        return NullLogger.instance;
    }
    if (logger.log !== undefined) {
        return logger;
    }
    return new ConsoleLogger(logger);
}
/** @private */
class SubjectSubscription {
    constructor(subject, observer) {
        this._subject = subject;
        this._observer = observer;
    }
    dispose() {
        const index = this._subject.observers.indexOf(this._observer);
        if (index > -1) {
            this._subject.observers.splice(index, 1);
        }
        if (this._subject.observers.length === 0 && this._subject.cancelCallback) {
            this._subject.cancelCallback().catch((_) => { });
        }
    }
}
/** @private */
class ConsoleLogger {
    constructor(minimumLogLevel) {
        this._minLevel = minimumLogLevel;
        this.out = console;
    }
    log(logLevel, message) {
        if (logLevel >= this._minLevel) {
            const msg = `[${new Date().toISOString()}] ${LogLevel[logLevel]}: ${message}`;
            switch (logLevel) {
                case LogLevel.Critical:
                case LogLevel.Error:
                    this.out.error(msg);
                    break;
                case LogLevel.Warning:
                    this.out.warn(msg);
                    break;
                case LogLevel.Information:
                    this.out.info(msg);
                    break;
                default:
                    // console.debug only goes to attached debuggers in Node, so we use console.log for Trace and Debug
                    this.out.log(msg);
                    break;
            }
        }
    }
}
/** @private */
function getUserAgentHeader() {
    let userAgentHeaderName = "X-SignalR-User-Agent";
    if (Platform.isNode) {
        userAgentHeaderName = "User-Agent";
    }
    return [userAgentHeaderName, constructUserAgent(VERSION, getOsName(), getRuntime(), getRuntimeVersion())];
}
/** @private */
function constructUserAgent(version, os, runtime, runtimeVersion) {
    // Microsoft SignalR/[Version] ([Detailed Version]; [Operating System]; [Runtime]; [Runtime Version])
    let userAgent = "Microsoft SignalR/";
    const majorAndMinor = version.split(".");
    userAgent += `${majorAndMinor[0]}.${majorAndMinor[1]}`;
    userAgent += ` (${version}; `;
    if (os && os !== "") {
        userAgent += `${os}; `;
    }
    else {
        userAgent += "Unknown OS; ";
    }
    userAgent += `${runtime}`;
    if (runtimeVersion) {
        userAgent += `; ${runtimeVersion}`;
    }
    else {
        userAgent += "; Unknown Runtime Version";
    }
    userAgent += ")";
    return userAgent;
}
// eslint-disable-next-line spaced-comment
/*#__PURE__*/ function getOsName() {
    if (Platform.isNode) {
        switch (process.platform) {
            case "win32":
                return "Windows NT";
            case "darwin":
                return "macOS";
            case "linux":
                return "Linux";
            default:
                return process.platform;
        }
    }
    else {
        return "";
    }
}
// eslint-disable-next-line spaced-comment
/*#__PURE__*/ function getRuntimeVersion() {
    if (Platform.isNode) {
        return process.versions.node;
    }
    return undefined;
}
function getRuntime() {
    if (Platform.isNode) {
        return "NodeJS";
    }
    else {
        return "Browser";
    }
}
/** @private */
function getErrorString(e) {
    if (e.stack) {
        return e.stack;
    }
    else if (e.message) {
        return e.message;
    }
    return `${e}`;
}
/** @private */
function getGlobalThis() {
    // globalThis is semi-new and not available in Node until v12
    if (typeof globalThis !== "undefined") {
        return globalThis;
    }
    if (typeof self !== "undefined") {
        return self;
    }
    if (typeof window !== "undefined") {
        return window;
    }
    if (typeof __webpack_require__.g !== "undefined") {
        return __webpack_require__.g;
    }
    throw new Error("could not find global");
}

;// CONCATENATED MODULE: ./src/FetchHttpClient.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.




class FetchHttpClient extends HttpClient {
    constructor(logger) {
        super();
        this._logger = logger;
        if (typeof fetch === "undefined") {
            // In order to ignore the dynamic require in webpack builds we need to do this magic
            // @ts-ignore: TS doesn't know about these names
            const requireFunc =  true ? require : 0;
            // Cookies aren't automatically handled in Node so we need to add a CookieJar to preserve cookies across requests
            this._jar = new (requireFunc("tough-cookie")).CookieJar();
            this._fetchType = requireFunc("node-fetch");
            // node-fetch doesn't have a nice API for getting and setting cookies
            // fetch-cookie will wrap a fetch implementation with a default CookieJar or a provided one
            this._fetchType = requireFunc("fetch-cookie")(this._fetchType, this._jar);
        }
        else {
            this._fetchType = fetch.bind(getGlobalThis());
        }
        if (typeof AbortController === "undefined") {
            // In order to ignore the dynamic require in webpack builds we need to do this magic
            // @ts-ignore: TS doesn't know about these names
            const requireFunc =  true ? require : 0;
            // Node needs EventListener methods on AbortController which our custom polyfill doesn't provide
            this._abortControllerType = requireFunc("abort-controller");
        }
        else {
            this._abortControllerType = AbortController;
        }
    }
    /** @inheritDoc */
    async send(request) {
        // Check that abort was not signaled before calling send
        if (request.abortSignal && request.abortSignal.aborted) {
            throw new AbortError();
        }
        if (!request.method) {
            throw new Error("No method defined.");
        }
        if (!request.url) {
            throw new Error("No url defined.");
        }
        const abortController = new this._abortControllerType();
        let error;
        // Hook our abortSignal into the abort controller
        if (request.abortSignal) {
            request.abortSignal.onabort = () => {
                abortController.abort();
                error = new AbortError();
            };
        }
        // If a timeout has been passed in, setup a timeout to call abort
        // Type needs to be any to fit window.setTimeout and NodeJS.setTimeout
        let timeoutId = null;
        if (request.timeout) {
            const msTimeout = request.timeout;
            timeoutId = setTimeout(() => {
                abortController.abort();
                this._logger.log(LogLevel.Warning, `Timeout from HTTP request.`);
                error = new TimeoutError();
            }, msTimeout);
        }
        let response;
        try {
            response = await this._fetchType(request.url, {
                body: request.content,
                cache: "no-cache",
                credentials: request.withCredentials === true ? "include" : "same-origin",
                headers: {
                    "Content-Type": "text/plain;charset=UTF-8",
                    "X-Requested-With": "XMLHttpRequest",
                    ...request.headers,
                },
                method: request.method,
                mode: "cors",
                redirect: "follow",
                signal: abortController.signal,
            });
        }
        catch (e) {
            if (error) {
                throw error;
            }
            this._logger.log(LogLevel.Warning, `Error from HTTP request. ${e}.`);
            throw e;
        }
        finally {
            if (timeoutId) {
                clearTimeout(timeoutId);
            }
            if (request.abortSignal) {
                request.abortSignal.onabort = null;
            }
        }
        if (!response.ok) {
            const errorMessage = await deserializeContent(response, "text");
            throw new HttpError(errorMessage || response.statusText, response.status);
        }
        const content = deserializeContent(response, request.responseType);
        const payload = await content;
        return new HttpResponse(response.status, response.statusText, payload);
    }
    getCookieString(url) {
        let cookies = "";
        if (Platform.isNode && this._jar) {
            // @ts-ignore: unused variable
            this._jar.getCookies(url, (e, c) => cookies = c.join("; "));
        }
        return cookies;
    }
}
function deserializeContent(response, responseType) {
    let content;
    switch (responseType) {
        case "arraybuffer":
            content = response.arrayBuffer();
            break;
        case "text":
            content = response.text();
            break;
        case "blob":
        case "document":
        case "json":
            throw new Error(`${responseType} is not supported.`);
        default:
            content = response.text();
            break;
    }
    return content;
}

;// CONCATENATED MODULE: ./src/XhrHttpClient.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.



class XhrHttpClient extends HttpClient {
    constructor(logger) {
        super();
        this._logger = logger;
    }
    /** @inheritDoc */
    send(request) {
        // Check that abort was not signaled before calling send
        if (request.abortSignal && request.abortSignal.aborted) {
            return Promise.reject(new AbortError());
        }
        if (!request.method) {
            return Promise.reject(new Error("No method defined."));
        }
        if (!request.url) {
            return Promise.reject(new Error("No url defined."));
        }
        return new Promise((resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open(request.method, request.url, true);
            xhr.withCredentials = request.withCredentials === undefined ? true : request.withCredentials;
            xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest");
            // Explicitly setting the Content-Type header for React Native on Android platform.
            xhr.setRequestHeader("Content-Type", "text/plain;charset=UTF-8");
            const headers = request.headers;
            if (headers) {
                Object.keys(headers)
                    .forEach((header) => {
                    xhr.setRequestHeader(header, headers[header]);
                });
            }
            if (request.responseType) {
                xhr.responseType = request.responseType;
            }
            if (request.abortSignal) {
                request.abortSignal.onabort = () => {
                    xhr.abort();
                    reject(new AbortError());
                };
            }
            if (request.timeout) {
                xhr.timeout = request.timeout;
            }
            xhr.onload = () => {
                if (request.abortSignal) {
                    request.abortSignal.onabort = null;
                }
                if (xhr.status >= 200 && xhr.status < 300) {
                    resolve(new HttpResponse(xhr.status, xhr.statusText, xhr.response || xhr.responseText));
                }
                else {
                    reject(new HttpError(xhr.response || xhr.responseText || xhr.statusText, xhr.status));
                }
            };
            xhr.onerror = () => {
                this._logger.log(LogLevel.Warning, `Error from HTTP request. ${xhr.status}: ${xhr.statusText}.`);
                reject(new HttpError(xhr.statusText, xhr.status));
            };
            xhr.ontimeout = () => {
                this._logger.log(LogLevel.Warning, `Timeout from HTTP request.`);
                reject(new TimeoutError());
            };
            xhr.send(request.content || "");
        });
    }
}

;// CONCATENATED MODULE: ./src/DefaultHttpClient.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.





/** Default implementation of {@link @microsoft/signalr.HttpClient}. */
class DefaultHttpClient extends HttpClient {
    /** Creates a new instance of the {@link @microsoft/signalr.DefaultHttpClient}, using the provided {@link @microsoft/signalr.ILogger} to log messages. */
    constructor(logger) {
        super();
        if (typeof fetch !== "undefined" || Platform.isNode) {
            this._httpClient = new FetchHttpClient(logger);
        }
        else if (typeof XMLHttpRequest !== "undefined") {
            this._httpClient = new XhrHttpClient(logger);
        }
        else {
            throw new Error("No usable HttpClient found.");
        }
    }
    /** @inheritDoc */
    send(request) {
        // Check that abort was not signaled before calling send
        if (request.abortSignal && request.abortSignal.aborted) {
            return Promise.reject(new AbortError());
        }
        if (!request.method) {
            return Promise.reject(new Error("No method defined."));
        }
        if (!request.url) {
            return Promise.reject(new Error("No url defined."));
        }
        return this._httpClient.send(request);
    }
    getCookieString(url) {
        return this._httpClient.getCookieString(url);
    }
}

;// CONCATENATED MODULE: ./src/TextMessageFormat.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Not exported from index
/** @private */
class TextMessageFormat {
    static write(output) {
        return `${output}${TextMessageFormat.RecordSeparator}`;
    }
    static parse(input) {
        if (input[input.length - 1] !== TextMessageFormat.RecordSeparator) {
            throw new Error("Message is incomplete.");
        }
        const messages = input.split(TextMessageFormat.RecordSeparator);
        messages.pop();
        return messages;
    }
}
TextMessageFormat.RecordSeparatorCode = 0x1e;
TextMessageFormat.RecordSeparator = String.fromCharCode(TextMessageFormat.RecordSeparatorCode);

;// CONCATENATED MODULE: ./src/HandshakeProtocol.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


/** @private */
class HandshakeProtocol {
    // Handshake request is always JSON
    writeHandshakeRequest(handshakeRequest) {
        return TextMessageFormat.write(JSON.stringify(handshakeRequest));
    }
    parseHandshakeResponse(data) {
        let messageData;
        let remainingData;
        if (isArrayBuffer(data)) {
            // Format is binary but still need to read JSON text from handshake response
            const binaryData = new Uint8Array(data);
            const separatorIndex = binaryData.indexOf(TextMessageFormat.RecordSeparatorCode);
            if (separatorIndex === -1) {
                throw new Error("Message is incomplete.");
            }
            // content before separator is handshake response
            // optional content after is additional messages
            const responseLength = separatorIndex + 1;
            messageData = String.fromCharCode.apply(null, Array.prototype.slice.call(binaryData.slice(0, responseLength)));
            remainingData = (binaryData.byteLength > responseLength) ? binaryData.slice(responseLength).buffer : null;
        }
        else {
            const textData = data;
            const separatorIndex = textData.indexOf(TextMessageFormat.RecordSeparator);
            if (separatorIndex === -1) {
                throw new Error("Message is incomplete.");
            }
            // content before separator is handshake response
            // optional content after is additional messages
            const responseLength = separatorIndex + 1;
            messageData = textData.substring(0, responseLength);
            remainingData = (textData.length > responseLength) ? textData.substring(responseLength) : null;
        }
        // At this point we should have just the single handshake message
        const messages = TextMessageFormat.parse(messageData);
        const response = JSON.parse(messages[0]);
        if (response.type) {
            throw new Error("Expected a handshake response from the server.");
        }
        const responseMessage = response;
        // multiple messages could have arrived with handshake
        // return additional data to be parsed as usual, or null if all parsed
        return [remainingData, responseMessage];
    }
}

;// CONCATENATED MODULE: ./src/IHubProtocol.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
/** Defines the type of a Hub Message. */
var MessageType;
(function (MessageType) {
    /** Indicates the message is an Invocation message and implements the {@link @microsoft/signalr.InvocationMessage} interface. */
    MessageType[MessageType["Invocation"] = 1] = "Invocation";
    /** Indicates the message is a StreamItem message and implements the {@link @microsoft/signalr.StreamItemMessage} interface. */
    MessageType[MessageType["StreamItem"] = 2] = "StreamItem";
    /** Indicates the message is a Completion message and implements the {@link @microsoft/signalr.CompletionMessage} interface. */
    MessageType[MessageType["Completion"] = 3] = "Completion";
    /** Indicates the message is a Stream Invocation message and implements the {@link @microsoft/signalr.StreamInvocationMessage} interface. */
    MessageType[MessageType["StreamInvocation"] = 4] = "StreamInvocation";
    /** Indicates the message is a Cancel Invocation message and implements the {@link @microsoft/signalr.CancelInvocationMessage} interface. */
    MessageType[MessageType["CancelInvocation"] = 5] = "CancelInvocation";
    /** Indicates the message is a Ping message and implements the {@link @microsoft/signalr.PingMessage} interface. */
    MessageType[MessageType["Ping"] = 6] = "Ping";
    /** Indicates the message is a Close message and implements the {@link @microsoft/signalr.CloseMessage} interface. */
    MessageType[MessageType["Close"] = 7] = "Close";
})(MessageType || (MessageType = {}));

;// CONCATENATED MODULE: ./src/Subject.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/** Stream implementation to stream items to the server. */
class Subject {
    constructor() {
        this.observers = [];
    }
    next(item) {
        for (const observer of this.observers) {
            observer.next(item);
        }
    }
    error(err) {
        for (const observer of this.observers) {
            if (observer.error) {
                observer.error(err);
            }
        }
    }
    complete() {
        for (const observer of this.observers) {
            if (observer.complete) {
                observer.complete();
            }
        }
    }
    subscribe(observer) {
        this.observers.push(observer);
        return new SubjectSubscription(this, observer);
    }
}

;// CONCATENATED MODULE: ./src/HubConnection.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.





const DEFAULT_TIMEOUT_IN_MS = 30 * 1000;
const DEFAULT_PING_INTERVAL_IN_MS = 15 * 1000;
/** Describes the current state of the {@link HubConnection} to the server. */
var HubConnectionState;
(function (HubConnectionState) {
    /** The hub connection is disconnected. */
    HubConnectionState["Disconnected"] = "Disconnected";
    /** The hub connection is connecting. */
    HubConnectionState["Connecting"] = "Connecting";
    /** The hub connection is connected. */
    HubConnectionState["Connected"] = "Connected";
    /** The hub connection is disconnecting. */
    HubConnectionState["Disconnecting"] = "Disconnecting";
    /** The hub connection is reconnecting. */
    HubConnectionState["Reconnecting"] = "Reconnecting";
})(HubConnectionState || (HubConnectionState = {}));
/** Represents a connection to a SignalR Hub. */
class HubConnection {
    constructor(connection, logger, protocol, reconnectPolicy) {
        this._nextKeepAlive = 0;
        this._freezeEventListener = () => {
            this._logger.log(LogLevel.Warning, "The page is being frozen, this will likely lead to the connection being closed and messages being lost. For more information see the docs at https://docs.microsoft.com/aspnet/core/signalr/javascript-client#bsleep");
        };
        Arg.isRequired(connection, "connection");
        Arg.isRequired(logger, "logger");
        Arg.isRequired(protocol, "protocol");
        this.serverTimeoutInMilliseconds = DEFAULT_TIMEOUT_IN_MS;
        this.keepAliveIntervalInMilliseconds = DEFAULT_PING_INTERVAL_IN_MS;
        this._logger = logger;
        this._protocol = protocol;
        this.connection = connection;
        this._reconnectPolicy = reconnectPolicy;
        this._handshakeProtocol = new HandshakeProtocol();
        this.connection.onreceive = (data) => this._processIncomingData(data);
        this.connection.onclose = (error) => this._connectionClosed(error);
        this._callbacks = {};
        this._methods = {};
        this._closedCallbacks = [];
        this._reconnectingCallbacks = [];
        this._reconnectedCallbacks = [];
        this._invocationId = 0;
        this._receivedHandshakeResponse = false;
        this._connectionState = HubConnectionState.Disconnected;
        this._connectionStarted = false;
        this._cachedPingMessage = this._protocol.writeMessage({ type: MessageType.Ping });
    }
    /** @internal */
    // Using a public static factory method means we can have a private constructor and an _internal_
    // create method that can be used by HubConnectionBuilder. An "internal" constructor would just
    // be stripped away and the '.d.ts' file would have no constructor, which is interpreted as a
    // public parameter-less constructor.
    static create(connection, logger, protocol, reconnectPolicy) {
        return new HubConnection(connection, logger, protocol, reconnectPolicy);
    }
    /** Indicates the state of the {@link HubConnection} to the server. */
    get state() {
        return this._connectionState;
    }
    /** Represents the connection id of the {@link HubConnection} on the server. The connection id will be null when the connection is either
     *  in the disconnected state or if the negotiation step was skipped.
     */
    get connectionId() {
        return this.connection ? (this.connection.connectionId || null) : null;
    }
    /** Indicates the url of the {@link HubConnection} to the server. */
    get baseUrl() {
        return this.connection.baseUrl || "";
    }
    /**
     * Sets a new url for the HubConnection. Note that the url can only be changed when the connection is in either the Disconnected or
     * Reconnecting states.
     * @param {string} url The url to connect to.
     */
    set baseUrl(url) {
        if (this._connectionState !== HubConnectionState.Disconnected && this._connectionState !== HubConnectionState.Reconnecting) {
            throw new Error("The HubConnection must be in the Disconnected or Reconnecting state to change the url.");
        }
        if (!url) {
            throw new Error("The HubConnection url must be a valid url.");
        }
        this.connection.baseUrl = url;
    }
    /** Starts the connection.
     *
     * @returns {Promise<void>} A Promise that resolves when the connection has been successfully established, or rejects with an error.
     */
    start() {
        this._startPromise = this._startWithStateTransitions();
        return this._startPromise;
    }
    async _startWithStateTransitions() {
        if (this._connectionState !== HubConnectionState.Disconnected) {
            return Promise.reject(new Error("Cannot start a HubConnection that is not in the 'Disconnected' state."));
        }
        this._connectionState = HubConnectionState.Connecting;
        this._logger.log(LogLevel.Debug, "Starting HubConnection.");
        try {
            await this._startInternal();
            if (Platform.isBrowser) {
                // Log when the browser freezes the tab so users know why their connection unexpectedly stopped working
                window.document.addEventListener("freeze", this._freezeEventListener);
            }
            this._connectionState = HubConnectionState.Connected;
            this._connectionStarted = true;
            this._logger.log(LogLevel.Debug, "HubConnection connected successfully.");
        }
        catch (e) {
            this._connectionState = HubConnectionState.Disconnected;
            this._logger.log(LogLevel.Debug, `HubConnection failed to start successfully because of error '${e}'.`);
            return Promise.reject(e);
        }
    }
    async _startInternal() {
        this._stopDuringStartError = undefined;
        this._receivedHandshakeResponse = false;
        // Set up the promise before any connection is (re)started otherwise it could race with received messages
        const handshakePromise = new Promise((resolve, reject) => {
            this._handshakeResolver = resolve;
            this._handshakeRejecter = reject;
        });
        await this.connection.start(this._protocol.transferFormat);
        try {
            const handshakeRequest = {
                protocol: this._protocol.name,
                version: this._protocol.version,
            };
            this._logger.log(LogLevel.Debug, "Sending handshake request.");
            await this._sendMessage(this._handshakeProtocol.writeHandshakeRequest(handshakeRequest));
            this._logger.log(LogLevel.Information, `Using HubProtocol '${this._protocol.name}'.`);
            // defensively cleanup timeout in case we receive a message from the server before we finish start
            this._cleanupTimeout();
            this._resetTimeoutPeriod();
            this._resetKeepAliveInterval();
            await handshakePromise;
            // It's important to check the stopDuringStartError instead of just relying on the handshakePromise
            // being rejected on close, because this continuation can run after both the handshake completed successfully
            // and the connection was closed.
            if (this._stopDuringStartError) {
                // It's important to throw instead of returning a rejected promise, because we don't want to allow any state
                // transitions to occur between now and the calling code observing the exceptions. Returning a rejected promise
                // will cause the calling continuation to get scheduled to run later.
                // eslint-disable-next-line @typescript-eslint/no-throw-literal
                throw this._stopDuringStartError;
            }
        }
        catch (e) {
            this._logger.log(LogLevel.Debug, `Hub handshake failed with error '${e}' during start(). Stopping HubConnection.`);
            this._cleanupTimeout();
            this._cleanupPingTimer();
            // HttpConnection.stop() should not complete until after the onclose callback is invoked.
            // This will transition the HubConnection to the disconnected state before HttpConnection.stop() completes.
            await this.connection.stop(e);
            throw e;
        }
    }
    /** Stops the connection.
     *
     * @returns {Promise<void>} A Promise that resolves when the connection has been successfully terminated, or rejects with an error.
     */
    async stop() {
        // Capture the start promise before the connection might be restarted in an onclose callback.
        const startPromise = this._startPromise;
        this._stopPromise = this._stopInternal();
        await this._stopPromise;
        try {
            // Awaiting undefined continues immediately
            await startPromise;
        }
        catch (e) {
            // This exception is returned to the user as a rejected Promise from the start method.
        }
    }
    _stopInternal(error) {
        if (this._connectionState === HubConnectionState.Disconnected) {
            this._logger.log(LogLevel.Debug, `Call to HubConnection.stop(${error}) ignored because it is already in the disconnected state.`);
            return Promise.resolve();
        }
        if (this._connectionState === HubConnectionState.Disconnecting) {
            this._logger.log(LogLevel.Debug, `Call to HttpConnection.stop(${error}) ignored because the connection is already in the disconnecting state.`);
            return this._stopPromise;
        }
        this._connectionState = HubConnectionState.Disconnecting;
        this._logger.log(LogLevel.Debug, "Stopping HubConnection.");
        if (this._reconnectDelayHandle) {
            // We're in a reconnect delay which means the underlying connection is currently already stopped.
            // Just clear the handle to stop the reconnect loop (which no one is waiting on thankfully) and
            // fire the onclose callbacks.
            this._logger.log(LogLevel.Debug, "Connection stopped during reconnect delay. Done reconnecting.");
            clearTimeout(this._reconnectDelayHandle);
            this._reconnectDelayHandle = undefined;
            this._completeClose();
            return Promise.resolve();
        }
        this._cleanupTimeout();
        this._cleanupPingTimer();
        this._stopDuringStartError = error || new Error("The connection was stopped before the hub handshake could complete.");
        // HttpConnection.stop() should not complete until after either HttpConnection.start() fails
        // or the onclose callback is invoked. The onclose callback will transition the HubConnection
        // to the disconnected state if need be before HttpConnection.stop() completes.
        return this.connection.stop(error);
    }
    /** Invokes a streaming hub method on the server using the specified name and arguments.
     *
     * @typeparam T The type of the items returned by the server.
     * @param {string} methodName The name of the server method to invoke.
     * @param {any[]} args The arguments used to invoke the server method.
     * @returns {IStreamResult<T>} An object that yields results from the server as they are received.
     */
    stream(methodName, ...args) {
        const [streams, streamIds] = this._replaceStreamingParams(args);
        const invocationDescriptor = this._createStreamInvocation(methodName, args, streamIds);
        // eslint-disable-next-line prefer-const
        let promiseQueue;
        const subject = new Subject();
        subject.cancelCallback = () => {
            const cancelInvocation = this._createCancelInvocation(invocationDescriptor.invocationId);
            delete this._callbacks[invocationDescriptor.invocationId];
            return promiseQueue.then(() => {
                return this._sendWithProtocol(cancelInvocation);
            });
        };
        this._callbacks[invocationDescriptor.invocationId] = (invocationEvent, error) => {
            if (error) {
                subject.error(error);
                return;
            }
            else if (invocationEvent) {
                // invocationEvent will not be null when an error is not passed to the callback
                if (invocationEvent.type === MessageType.Completion) {
                    if (invocationEvent.error) {
                        subject.error(new Error(invocationEvent.error));
                    }
                    else {
                        subject.complete();
                    }
                }
                else {
                    subject.next((invocationEvent.item));
                }
            }
        };
        promiseQueue = this._sendWithProtocol(invocationDescriptor)
            .catch((e) => {
            subject.error(e);
            delete this._callbacks[invocationDescriptor.invocationId];
        });
        this._launchStreams(streams, promiseQueue);
        return subject;
    }
    _sendMessage(message) {
        this._resetKeepAliveInterval();
        return this.connection.send(message);
    }
    /**
     * Sends a js object to the server.
     * @param message The js object to serialize and send.
     */
    _sendWithProtocol(message) {
        return this._sendMessage(this._protocol.writeMessage(message));
    }
    /** Invokes a hub method on the server using the specified name and arguments. Does not wait for a response from the receiver.
     *
     * The Promise returned by this method resolves when the client has sent the invocation to the server. The server may still
     * be processing the invocation.
     *
     * @param {string} methodName The name of the server method to invoke.
     * @param {any[]} args The arguments used to invoke the server method.
     * @returns {Promise<void>} A Promise that resolves when the invocation has been successfully sent, or rejects with an error.
     */
    send(methodName, ...args) {
        const [streams, streamIds] = this._replaceStreamingParams(args);
        const sendPromise = this._sendWithProtocol(this._createInvocation(methodName, args, true, streamIds));
        this._launchStreams(streams, sendPromise);
        return sendPromise;
    }
    /** Invokes a hub method on the server using the specified name and arguments.
     *
     * The Promise returned by this method resolves when the server indicates it has finished invoking the method. When the promise
     * resolves, the server has finished invoking the method. If the server method returns a result, it is produced as the result of
     * resolving the Promise.
     *
     * @typeparam T The expected return type.
     * @param {string} methodName The name of the server method to invoke.
     * @param {any[]} args The arguments used to invoke the server method.
     * @returns {Promise<T>} A Promise that resolves with the result of the server method (if any), or rejects with an error.
     */
    invoke(methodName, ...args) {
        const [streams, streamIds] = this._replaceStreamingParams(args);
        const invocationDescriptor = this._createInvocation(methodName, args, false, streamIds);
        const p = new Promise((resolve, reject) => {
            // invocationId will always have a value for a non-blocking invocation
            this._callbacks[invocationDescriptor.invocationId] = (invocationEvent, error) => {
                if (error) {
                    reject(error);
                    return;
                }
                else if (invocationEvent) {
                    // invocationEvent will not be null when an error is not passed to the callback
                    if (invocationEvent.type === MessageType.Completion) {
                        if (invocationEvent.error) {
                            reject(new Error(invocationEvent.error));
                        }
                        else {
                            resolve(invocationEvent.result);
                        }
                    }
                    else {
                        reject(new Error(`Unexpected message type: ${invocationEvent.type}`));
                    }
                }
            };
            const promiseQueue = this._sendWithProtocol(invocationDescriptor)
                .catch((e) => {
                reject(e);
                // invocationId will always have a value for a non-blocking invocation
                delete this._callbacks[invocationDescriptor.invocationId];
            });
            this._launchStreams(streams, promiseQueue);
        });
        return p;
    }
    /** Registers a handler that will be invoked when the hub method with the specified method name is invoked.
     *
     * @param {string} methodName The name of the hub method to define.
     * @param {Function} newMethod The handler that will be raised when the hub method is invoked.
     */
    on(methodName, newMethod) {
        if (!methodName || !newMethod) {
            return;
        }
        methodName = methodName.toLowerCase();
        if (!this._methods[methodName]) {
            this._methods[methodName] = [];
        }
        // Preventing adding the same handler multiple times.
        if (this._methods[methodName].indexOf(newMethod) !== -1) {
            return;
        }
        this._methods[methodName].push(newMethod);
    }
    off(methodName, method) {
        if (!methodName) {
            return;
        }
        methodName = methodName.toLowerCase();
        const handlers = this._methods[methodName];
        if (!handlers) {
            return;
        }
        if (method) {
            const removeIdx = handlers.indexOf(method);
            if (removeIdx !== -1) {
                handlers.splice(removeIdx, 1);
                if (handlers.length === 0) {
                    delete this._methods[methodName];
                }
            }
        }
        else {
            delete this._methods[methodName];
        }
    }
    /** Registers a handler that will be invoked when the connection is closed.
     *
     * @param {Function} callback The handler that will be invoked when the connection is closed. Optionally receives a single argument containing the error that caused the connection to close (if any).
     */
    onclose(callback) {
        if (callback) {
            this._closedCallbacks.push(callback);
        }
    }
    /** Registers a handler that will be invoked when the connection starts reconnecting.
     *
     * @param {Function} callback The handler that will be invoked when the connection starts reconnecting. Optionally receives a single argument containing the error that caused the connection to start reconnecting (if any).
     */
    onreconnecting(callback) {
        if (callback) {
            this._reconnectingCallbacks.push(callback);
        }
    }
    /** Registers a handler that will be invoked when the connection successfully reconnects.
     *
     * @param {Function} callback The handler that will be invoked when the connection successfully reconnects.
     */
    onreconnected(callback) {
        if (callback) {
            this._reconnectedCallbacks.push(callback);
        }
    }
    _processIncomingData(data) {
        this._cleanupTimeout();
        if (!this._receivedHandshakeResponse) {
            data = this._processHandshakeResponse(data);
            this._receivedHandshakeResponse = true;
        }
        // Data may have all been read when processing handshake response
        if (data) {
            // Parse the messages
            const messages = this._protocol.parseMessages(data, this._logger);
            for (const message of messages) {
                switch (message.type) {
                    case MessageType.Invocation:
                        this._invokeClientMethod(message);
                        break;
                    case MessageType.StreamItem:
                    case MessageType.Completion: {
                        const callback = this._callbacks[message.invocationId];
                        if (callback) {
                            if (message.type === MessageType.Completion) {
                                delete this._callbacks[message.invocationId];
                            }
                            try {
                                callback(message);
                            }
                            catch (e) {
                                this._logger.log(LogLevel.Error, `Stream callback threw error: ${getErrorString(e)}`);
                            }
                        }
                        break;
                    }
                    case MessageType.Ping:
                        // Don't care about pings
                        break;
                    case MessageType.Close: {
                        this._logger.log(LogLevel.Information, "Close message received from server.");
                        const error = message.error ? new Error("Server returned an error on close: " + message.error) : undefined;
                        if (message.allowReconnect === true) {
                            // It feels wrong not to await connection.stop() here, but processIncomingData is called as part of an onreceive callback which is not async,
                            // this is already the behavior for serverTimeout(), and HttpConnection.Stop() should catch and log all possible exceptions.
                            // eslint-disable-next-line @typescript-eslint/no-floating-promises
                            this.connection.stop(error);
                        }
                        else {
                            // We cannot await stopInternal() here, but subsequent calls to stop() will await this if stopInternal() is still ongoing.
                            this._stopPromise = this._stopInternal(error);
                        }
                        break;
                    }
                    default:
                        this._logger.log(LogLevel.Warning, `Invalid message type: ${message.type}.`);
                        break;
                }
            }
        }
        this._resetTimeoutPeriod();
    }
    _processHandshakeResponse(data) {
        let responseMessage;
        let remainingData;
        try {
            [remainingData, responseMessage] = this._handshakeProtocol.parseHandshakeResponse(data);
        }
        catch (e) {
            const message = "Error parsing handshake response: " + e;
            this._logger.log(LogLevel.Error, message);
            const error = new Error(message);
            this._handshakeRejecter(error);
            throw error;
        }
        if (responseMessage.error) {
            const message = "Server returned handshake error: " + responseMessage.error;
            this._logger.log(LogLevel.Error, message);
            const error = new Error(message);
            this._handshakeRejecter(error);
            throw error;
        }
        else {
            this._logger.log(LogLevel.Debug, "Server handshake complete.");
        }
        this._handshakeResolver();
        return remainingData;
    }
    _resetKeepAliveInterval() {
        if (this.connection.features.inherentKeepAlive) {
            return;
        }
        // Set the time we want the next keep alive to be sent
        // Timer will be setup on next message receive
        this._nextKeepAlive = new Date().getTime() + this.keepAliveIntervalInMilliseconds;
        this._cleanupPingTimer();
    }
    _resetTimeoutPeriod() {
        if (!this.connection.features || !this.connection.features.inherentKeepAlive) {
            // Set the timeout timer
            this._timeoutHandle = setTimeout(() => this.serverTimeout(), this.serverTimeoutInMilliseconds);
            // Set keepAlive timer if there isn't one
            if (this._pingServerHandle === undefined) {
                let nextPing = this._nextKeepAlive - new Date().getTime();
                if (nextPing < 0) {
                    nextPing = 0;
                }
                // The timer needs to be set from a networking callback to avoid Chrome timer throttling from causing timers to run once a minute
                this._pingServerHandle = setTimeout(async () => {
                    if (this._connectionState === HubConnectionState.Connected) {
                        try {
                            await this._sendMessage(this._cachedPingMessage);
                        }
                        catch {
                            // We don't care about the error. It should be seen elsewhere in the client.
                            // The connection is probably in a bad or closed state now, cleanup the timer so it stops triggering
                            this._cleanupPingTimer();
                        }
                    }
                }, nextPing);
            }
        }
    }
    // eslint-disable-next-line @typescript-eslint/naming-convention
    serverTimeout() {
        // The server hasn't talked to us in a while. It doesn't like us anymore ... :(
        // Terminate the connection, but we don't need to wait on the promise. This could trigger reconnecting.
        // eslint-disable-next-line @typescript-eslint/no-floating-promises
        this.connection.stop(new Error("Server timeout elapsed without receiving a message from the server."));
    }
    _invokeClientMethod(invocationMessage) {
        const methods = this._methods[invocationMessage.target.toLowerCase()];
        if (methods) {
            try {
                methods.forEach((m) => m.apply(this, invocationMessage.arguments));
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `A callback for the method ${invocationMessage.target.toLowerCase()} threw error '${e}'.`);
            }
            if (invocationMessage.invocationId) {
                // This is not supported in v1. So we return an error to avoid blocking the server waiting for the response.
                const message = "Server requested a response, which is not supported in this version of the client.";
                this._logger.log(LogLevel.Error, message);
                // We don't want to wait on the stop itself.
                this._stopPromise = this._stopInternal(new Error(message));
            }
        }
        else {
            this._logger.log(LogLevel.Warning, `No client method with the name '${invocationMessage.target}' found.`);
        }
    }
    _connectionClosed(error) {
        this._logger.log(LogLevel.Debug, `HubConnection.connectionClosed(${error}) called while in state ${this._connectionState}.`);
        // Triggering this.handshakeRejecter is insufficient because it could already be resolved without the continuation having run yet.
        this._stopDuringStartError = this._stopDuringStartError || error || new Error("The underlying connection was closed before the hub handshake could complete.");
        // If the handshake is in progress, start will be waiting for the handshake promise, so we complete it.
        // If it has already completed, this should just noop.
        if (this._handshakeResolver) {
            this._handshakeResolver();
        }
        this._cancelCallbacksWithError(error || new Error("Invocation canceled due to the underlying connection being closed."));
        this._cleanupTimeout();
        this._cleanupPingTimer();
        if (this._connectionState === HubConnectionState.Disconnecting) {
            this._completeClose(error);
        }
        else if (this._connectionState === HubConnectionState.Connected && this._reconnectPolicy) {
            // eslint-disable-next-line @typescript-eslint/no-floating-promises
            this._reconnect(error);
        }
        else if (this._connectionState === HubConnectionState.Connected) {
            this._completeClose(error);
        }
        // If none of the above if conditions were true were called the HubConnection must be in either:
        // 1. The Connecting state in which case the handshakeResolver will complete it and stopDuringStartError will fail it.
        // 2. The Reconnecting state in which case the handshakeResolver will complete it and stopDuringStartError will fail the current reconnect attempt
        //    and potentially continue the reconnect() loop.
        // 3. The Disconnected state in which case we're already done.
    }
    _completeClose(error) {
        if (this._connectionStarted) {
            this._connectionState = HubConnectionState.Disconnected;
            this._connectionStarted = false;
            if (Platform.isBrowser) {
                window.document.removeEventListener("freeze", this._freezeEventListener);
            }
            try {
                this._closedCallbacks.forEach((c) => c.apply(this, [error]));
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `An onclose callback called with error '${error}' threw error '${e}'.`);
            }
        }
    }
    async _reconnect(error) {
        const reconnectStartTime = Date.now();
        let previousReconnectAttempts = 0;
        let retryError = error !== undefined ? error : new Error("Attempting to reconnect due to a unknown error.");
        let nextRetryDelay = this._getNextRetryDelay(previousReconnectAttempts++, 0, retryError);
        if (nextRetryDelay === null) {
            this._logger.log(LogLevel.Debug, "Connection not reconnecting because the IRetryPolicy returned null on the first reconnect attempt.");
            this._completeClose(error);
            return;
        }
        this._connectionState = HubConnectionState.Reconnecting;
        if (error) {
            this._logger.log(LogLevel.Information, `Connection reconnecting because of error '${error}'.`);
        }
        else {
            this._logger.log(LogLevel.Information, "Connection reconnecting.");
        }
        if (this._reconnectingCallbacks.length !== 0) {
            try {
                this._reconnectingCallbacks.forEach((c) => c.apply(this, [error]));
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `An onreconnecting callback called with error '${error}' threw error '${e}'.`);
            }
            // Exit early if an onreconnecting callback called connection.stop().
            if (this._connectionState !== HubConnectionState.Reconnecting) {
                this._logger.log(LogLevel.Debug, "Connection left the reconnecting state in onreconnecting callback. Done reconnecting.");
                return;
            }
        }
        while (nextRetryDelay !== null) {
            this._logger.log(LogLevel.Information, `Reconnect attempt number ${previousReconnectAttempts} will start in ${nextRetryDelay} ms.`);
            await new Promise((resolve) => {
                this._reconnectDelayHandle = setTimeout(resolve, nextRetryDelay);
            });
            this._reconnectDelayHandle = undefined;
            if (this._connectionState !== HubConnectionState.Reconnecting) {
                this._logger.log(LogLevel.Debug, "Connection left the reconnecting state during reconnect delay. Done reconnecting.");
                return;
            }
            try {
                await this._startInternal();
                this._connectionState = HubConnectionState.Connected;
                this._logger.log(LogLevel.Information, "HubConnection reconnected successfully.");
                if (this._reconnectedCallbacks.length !== 0) {
                    try {
                        this._reconnectedCallbacks.forEach((c) => c.apply(this, [this.connection.connectionId]));
                    }
                    catch (e) {
                        this._logger.log(LogLevel.Error, `An onreconnected callback called with connectionId '${this.connection.connectionId}; threw error '${e}'.`);
                    }
                }
                return;
            }
            catch (e) {
                this._logger.log(LogLevel.Information, `Reconnect attempt failed because of error '${e}'.`);
                if (this._connectionState !== HubConnectionState.Reconnecting) {
                    this._logger.log(LogLevel.Debug, `Connection moved to the '${this._connectionState}' from the reconnecting state during reconnect attempt. Done reconnecting.`);
                    // The TypeScript compiler thinks that connectionState must be Connected here. The TypeScript compiler is wrong.
                    if (this._connectionState === HubConnectionState.Disconnecting) {
                        this._completeClose();
                    }
                    return;
                }
                retryError = e instanceof Error ? e : new Error(e.toString());
                nextRetryDelay = this._getNextRetryDelay(previousReconnectAttempts++, Date.now() - reconnectStartTime, retryError);
            }
        }
        this._logger.log(LogLevel.Information, `Reconnect retries have been exhausted after ${Date.now() - reconnectStartTime} ms and ${previousReconnectAttempts} failed attempts. Connection disconnecting.`);
        this._completeClose();
    }
    _getNextRetryDelay(previousRetryCount, elapsedMilliseconds, retryReason) {
        try {
            return this._reconnectPolicy.nextRetryDelayInMilliseconds({
                elapsedMilliseconds,
                previousRetryCount,
                retryReason,
            });
        }
        catch (e) {
            this._logger.log(LogLevel.Error, `IRetryPolicy.nextRetryDelayInMilliseconds(${previousRetryCount}, ${elapsedMilliseconds}) threw error '${e}'.`);
            return null;
        }
    }
    _cancelCallbacksWithError(error) {
        const callbacks = this._callbacks;
        this._callbacks = {};
        Object.keys(callbacks)
            .forEach((key) => {
            const callback = callbacks[key];
            try {
                callback(null, error);
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `Stream 'error' callback called with '${error}' threw error: ${getErrorString(e)}`);
            }
        });
    }
    _cleanupPingTimer() {
        if (this._pingServerHandle) {
            clearTimeout(this._pingServerHandle);
            this._pingServerHandle = undefined;
        }
    }
    _cleanupTimeout() {
        if (this._timeoutHandle) {
            clearTimeout(this._timeoutHandle);
        }
    }
    _createInvocation(methodName, args, nonblocking, streamIds) {
        if (nonblocking) {
            if (streamIds.length !== 0) {
                return {
                    arguments: args,
                    streamIds,
                    target: methodName,
                    type: MessageType.Invocation,
                };
            }
            else {
                return {
                    arguments: args,
                    target: methodName,
                    type: MessageType.Invocation,
                };
            }
        }
        else {
            const invocationId = this._invocationId;
            this._invocationId++;
            if (streamIds.length !== 0) {
                return {
                    arguments: args,
                    invocationId: invocationId.toString(),
                    streamIds,
                    target: methodName,
                    type: MessageType.Invocation,
                };
            }
            else {
                return {
                    arguments: args,
                    invocationId: invocationId.toString(),
                    target: methodName,
                    type: MessageType.Invocation,
                };
            }
        }
    }
    _launchStreams(streams, promiseQueue) {
        if (streams.length === 0) {
            return;
        }
        // Synchronize stream data so they arrive in-order on the server
        if (!promiseQueue) {
            promiseQueue = Promise.resolve();
        }
        // We want to iterate over the keys, since the keys are the stream ids
        // eslint-disable-next-line guard-for-in
        for (const streamId in streams) {
            streams[streamId].subscribe({
                complete: () => {
                    promiseQueue = promiseQueue.then(() => this._sendWithProtocol(this._createCompletionMessage(streamId)));
                },
                error: (err) => {
                    let message;
                    if (err instanceof Error) {
                        message = err.message;
                    }
                    else if (err && err.toString) {
                        message = err.toString();
                    }
                    else {
                        message = "Unknown error";
                    }
                    promiseQueue = promiseQueue.then(() => this._sendWithProtocol(this._createCompletionMessage(streamId, message)));
                },
                next: (item) => {
                    promiseQueue = promiseQueue.then(() => this._sendWithProtocol(this._createStreamItemMessage(streamId, item)));
                },
            });
        }
    }
    _replaceStreamingParams(args) {
        const streams = [];
        const streamIds = [];
        for (let i = 0; i < args.length; i++) {
            const argument = args[i];
            if (this._isObservable(argument)) {
                const streamId = this._invocationId;
                this._invocationId++;
                // Store the stream for later use
                streams[streamId] = argument;
                streamIds.push(streamId.toString());
                // remove stream from args
                args.splice(i, 1);
            }
        }
        return [streams, streamIds];
    }
    _isObservable(arg) {
        // This allows other stream implementations to just work (like rxjs)
        return arg && arg.subscribe && typeof arg.subscribe === "function";
    }
    _createStreamInvocation(methodName, args, streamIds) {
        const invocationId = this._invocationId;
        this._invocationId++;
        if (streamIds.length !== 0) {
            return {
                arguments: args,
                invocationId: invocationId.toString(),
                streamIds,
                target: methodName,
                type: MessageType.StreamInvocation,
            };
        }
        else {
            return {
                arguments: args,
                invocationId: invocationId.toString(),
                target: methodName,
                type: MessageType.StreamInvocation,
            };
        }
    }
    _createCancelInvocation(id) {
        return {
            invocationId: id,
            type: MessageType.CancelInvocation,
        };
    }
    _createStreamItemMessage(id, item) {
        return {
            invocationId: id,
            item,
            type: MessageType.StreamItem,
        };
    }
    _createCompletionMessage(id, error, result) {
        if (error) {
            return {
                error,
                invocationId: id,
                type: MessageType.Completion,
            };
        }
        return {
            invocationId: id,
            result,
            type: MessageType.Completion,
        };
    }
}

;// CONCATENATED MODULE: ./src/DefaultReconnectPolicy.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// 0, 2, 10, 30 second delays before reconnect attempts.
const DEFAULT_RETRY_DELAYS_IN_MILLISECONDS = [0, 2000, 10000, 30000, null];
/** @private */
class DefaultReconnectPolicy {
    constructor(retryDelays) {
        this._retryDelays = retryDelays !== undefined ? [...retryDelays, null] : DEFAULT_RETRY_DELAYS_IN_MILLISECONDS;
    }
    nextRetryDelayInMilliseconds(retryContext) {
        return this._retryDelays[retryContext.previousRetryCount];
    }
}

;// CONCATENATED MODULE: ./src/HeaderNames.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
class HeaderNames {
}
HeaderNames.Authorization = "Authorization";
HeaderNames.Cookie = "Cookie";

;// CONCATENATED MODULE: ./src/ITransport.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// This will be treated as a bit flag in the future, so we keep it using power-of-two values.
/** Specifies a specific HTTP transport type. */
var HttpTransportType;
(function (HttpTransportType) {
    /** Specifies no transport preference. */
    HttpTransportType[HttpTransportType["None"] = 0] = "None";
    /** Specifies the WebSockets transport. */
    HttpTransportType[HttpTransportType["WebSockets"] = 1] = "WebSockets";
    /** Specifies the Server-Sent Events transport. */
    HttpTransportType[HttpTransportType["ServerSentEvents"] = 2] = "ServerSentEvents";
    /** Specifies the Long Polling transport. */
    HttpTransportType[HttpTransportType["LongPolling"] = 4] = "LongPolling";
})(HttpTransportType || (HttpTransportType = {}));
/** Specifies the transfer format for a connection. */
var TransferFormat;
(function (TransferFormat) {
    /** Specifies that only text data will be transmitted over the connection. */
    TransferFormat[TransferFormat["Text"] = 1] = "Text";
    /** Specifies that binary data will be transmitted over the connection. */
    TransferFormat[TransferFormat["Binary"] = 2] = "Binary";
})(TransferFormat || (TransferFormat = {}));

;// CONCATENATED MODULE: ./src/AbortController.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Rough polyfill of https://developer.mozilla.org/en-US/docs/Web/API/AbortController
// We don't actually ever use the API being polyfilled, we always use the polyfill because
// it's a very new API right now.
// Not exported from index.
/** @private */
class AbortController_AbortController {
    constructor() {
        this._isAborted = false;
        this.onabort = null;
    }
    abort() {
        if (!this._isAborted) {
            this._isAborted = true;
            if (this.onabort) {
                this.onabort();
            }
        }
    }
    get signal() {
        return this;
    }
    get aborted() {
        return this._isAborted;
    }
}

;// CONCATENATED MODULE: ./src/LongPollingTransport.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.






// Not exported from 'index', this type is internal.
/** @private */
class LongPollingTransport {
    constructor(httpClient, accessTokenFactory, logger, options) {
        this._httpClient = httpClient;
        this._accessTokenFactory = accessTokenFactory;
        this._logger = logger;
        this._pollAbort = new AbortController_AbortController();
        this._options = options;
        this._running = false;
        this.onreceive = null;
        this.onclose = null;
    }
    // This is an internal type, not exported from 'index' so this is really just internal.
    get pollAborted() {
        return this._pollAbort.aborted;
    }
    async connect(url, transferFormat) {
        Arg.isRequired(url, "url");
        Arg.isRequired(transferFormat, "transferFormat");
        Arg.isIn(transferFormat, TransferFormat, "transferFormat");
        this._url = url;
        this._logger.log(LogLevel.Trace, "(LongPolling transport) Connecting.");
        // Allow binary format on Node and Browsers that support binary content (indicated by the presence of responseType property)
        if (transferFormat === TransferFormat.Binary &&
            (typeof XMLHttpRequest !== "undefined" && typeof new XMLHttpRequest().responseType !== "string")) {
            throw new Error("Binary protocols over XmlHttpRequest not implementing advanced features are not supported.");
        }
        const [name, value] = getUserAgentHeader();
        const headers = { [name]: value, ...this._options.headers };
        const pollOptions = {
            abortSignal: this._pollAbort.signal,
            headers,
            timeout: 100000,
            withCredentials: this._options.withCredentials,
        };
        if (transferFormat === TransferFormat.Binary) {
            pollOptions.responseType = "arraybuffer";
        }
        const token = await this._getAccessToken();
        this._updateHeaderToken(pollOptions, token);
        // Make initial long polling request
        // Server uses first long polling request to finish initializing connection and it returns without data
        const pollUrl = `${url}&_=${Date.now()}`;
        this._logger.log(LogLevel.Trace, `(LongPolling transport) polling: ${pollUrl}.`);
        const response = await this._httpClient.get(pollUrl, pollOptions);
        if (response.statusCode !== 200) {
            this._logger.log(LogLevel.Error, `(LongPolling transport) Unexpected response code: ${response.statusCode}.`);
            // Mark running as false so that the poll immediately ends and runs the close logic
            this._closeError = new HttpError(response.statusText || "", response.statusCode);
            this._running = false;
        }
        else {
            this._running = true;
        }
        this._receiving = this._poll(this._url, pollOptions);
    }
    async _getAccessToken() {
        if (this._accessTokenFactory) {
            return await this._accessTokenFactory();
        }
        return null;
    }
    _updateHeaderToken(request, token) {
        if (!request.headers) {
            request.headers = {};
        }
        if (token) {
            request.headers[HeaderNames.Authorization] = `Bearer ${token}`;
            return;
        }
        if (request.headers[HeaderNames.Authorization]) {
            delete request.headers[HeaderNames.Authorization];
        }
    }
    async _poll(url, pollOptions) {
        try {
            while (this._running) {
                // We have to get the access token on each poll, in case it changes
                const token = await this._getAccessToken();
                this._updateHeaderToken(pollOptions, token);
                try {
                    const pollUrl = `${url}&_=${Date.now()}`;
                    this._logger.log(LogLevel.Trace, `(LongPolling transport) polling: ${pollUrl}.`);
                    const response = await this._httpClient.get(pollUrl, pollOptions);
                    if (response.statusCode === 204) {
                        this._logger.log(LogLevel.Information, "(LongPolling transport) Poll terminated by server.");
                        this._running = false;
                    }
                    else if (response.statusCode !== 200) {
                        this._logger.log(LogLevel.Error, `(LongPolling transport) Unexpected response code: ${response.statusCode}.`);
                        // Unexpected status code
                        this._closeError = new HttpError(response.statusText || "", response.statusCode);
                        this._running = false;
                    }
                    else {
                        // Process the response
                        if (response.content) {
                            this._logger.log(LogLevel.Trace, `(LongPolling transport) data received. ${getDataDetail(response.content, this._options.logMessageContent)}.`);
                            if (this.onreceive) {
                                this.onreceive(response.content);
                            }
                        }
                        else {
                            // This is another way timeout manifest.
                            this._logger.log(LogLevel.Trace, "(LongPolling transport) Poll timed out, reissuing.");
                        }
                    }
                }
                catch (e) {
                    if (!this._running) {
                        // Log but disregard errors that occur after stopping
                        this._logger.log(LogLevel.Trace, `(LongPolling transport) Poll errored after shutdown: ${e.message}`);
                    }
                    else {
                        if (e instanceof TimeoutError) {
                            // Ignore timeouts and reissue the poll.
                            this._logger.log(LogLevel.Trace, "(LongPolling transport) Poll timed out, reissuing.");
                        }
                        else {
                            // Close the connection with the error as the result.
                            this._closeError = e;
                            this._running = false;
                        }
                    }
                }
            }
        }
        finally {
            this._logger.log(LogLevel.Trace, "(LongPolling transport) Polling complete.");
            // We will reach here with pollAborted==false when the server returned a response causing the transport to stop.
            // If pollAborted==true then client initiated the stop and the stop method will raise the close event after DELETE is sent.
            if (!this.pollAborted) {
                this._raiseOnClose();
            }
        }
    }
    async send(data) {
        if (!this._running) {
            return Promise.reject(new Error("Cannot send until the transport is connected"));
        }
        return sendMessage(this._logger, "LongPolling", this._httpClient, this._url, this._accessTokenFactory, data, this._options);
    }
    async stop() {
        this._logger.log(LogLevel.Trace, "(LongPolling transport) Stopping polling.");
        // Tell receiving loop to stop, abort any current request, and then wait for it to finish
        this._running = false;
        this._pollAbort.abort();
        try {
            await this._receiving;
            // Send DELETE to clean up long polling on the server
            this._logger.log(LogLevel.Trace, `(LongPolling transport) sending DELETE request to ${this._url}.`);
            const headers = {};
            const [name, value] = getUserAgentHeader();
            headers[name] = value;
            const deleteOptions = {
                headers: { ...headers, ...this._options.headers },
                timeout: this._options.timeout,
                withCredentials: this._options.withCredentials,
            };
            const token = await this._getAccessToken();
            this._updateHeaderToken(deleteOptions, token);
            await this._httpClient.delete(this._url, deleteOptions);
            this._logger.log(LogLevel.Trace, "(LongPolling transport) DELETE request sent.");
        }
        finally {
            this._logger.log(LogLevel.Trace, "(LongPolling transport) Stop finished.");
            // Raise close event here instead of in polling
            // It needs to happen after the DELETE request is sent
            this._raiseOnClose();
        }
    }
    _raiseOnClose() {
        if (this.onclose) {
            let logMessage = "(LongPolling transport) Firing onclose event.";
            if (this._closeError) {
                logMessage += " Error: " + this._closeError;
            }
            this._logger.log(LogLevel.Trace, logMessage);
            this.onclose(this._closeError);
        }
    }
}

;// CONCATENATED MODULE: ./src/ServerSentEventsTransport.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.



/** @private */
class ServerSentEventsTransport {
    constructor(httpClient, accessTokenFactory, logger, options) {
        this._httpClient = httpClient;
        this._accessTokenFactory = accessTokenFactory;
        this._logger = logger;
        this._options = options;
        this.onreceive = null;
        this.onclose = null;
    }
    async connect(url, transferFormat) {
        Arg.isRequired(url, "url");
        Arg.isRequired(transferFormat, "transferFormat");
        Arg.isIn(transferFormat, TransferFormat, "transferFormat");
        this._logger.log(LogLevel.Trace, "(SSE transport) Connecting.");
        // set url before accessTokenFactory because this.url is only for send and we set the auth header instead of the query string for send
        this._url = url;
        if (this._accessTokenFactory) {
            const token = await this._accessTokenFactory();
            if (token) {
                url += (url.indexOf("?") < 0 ? "?" : "&") + `access_token=${encodeURIComponent(token)}`;
            }
        }
        return new Promise((resolve, reject) => {
            let opened = false;
            if (transferFormat !== TransferFormat.Text) {
                reject(new Error("The Server-Sent Events transport only supports the 'Text' transfer format"));
                return;
            }
            let eventSource;
            if (Platform.isBrowser || Platform.isWebWorker) {
                eventSource = new this._options.EventSource(url, { withCredentials: this._options.withCredentials });
            }
            else {
                // Non-browser passes cookies via the dictionary
                const cookies = this._httpClient.getCookieString(url);
                const headers = {};
                headers.Cookie = cookies;
                const [name, value] = getUserAgentHeader();
                headers[name] = value;
                eventSource = new this._options.EventSource(url, { withCredentials: this._options.withCredentials, headers: { ...headers, ...this._options.headers } });
            }
            try {
                eventSource.onmessage = (e) => {
                    if (this.onreceive) {
                        try {
                            this._logger.log(LogLevel.Trace, `(SSE transport) data received. ${getDataDetail(e.data, this._options.logMessageContent)}.`);
                            this.onreceive(e.data);
                        }
                        catch (error) {
                            this._close(error);
                            return;
                        }
                    }
                };
                // @ts-ignore: not using event on purpose
                eventSource.onerror = (e) => {
                    // EventSource doesn't give any useful information about server side closes.
                    if (opened) {
                        this._close();
                    }
                    else {
                        reject(new Error("EventSource failed to connect. The connection could not be found on the server,"
                            + " either the connection ID is not present on the server, or a proxy is refusing/buffering the connection."
                            + " If you have multiple servers check that sticky sessions are enabled."));
                    }
                };
                eventSource.onopen = () => {
                    this._logger.log(LogLevel.Information, `SSE connected to ${this._url}`);
                    this._eventSource = eventSource;
                    opened = true;
                    resolve();
                };
            }
            catch (e) {
                reject(e);
                return;
            }
        });
    }
    async send(data) {
        if (!this._eventSource) {
            return Promise.reject(new Error("Cannot send until the transport is connected"));
        }
        return sendMessage(this._logger, "SSE", this._httpClient, this._url, this._accessTokenFactory, data, this._options);
    }
    stop() {
        this._close();
        return Promise.resolve();
    }
    _close(e) {
        if (this._eventSource) {
            this._eventSource.close();
            this._eventSource = undefined;
            if (this.onclose) {
                this.onclose(e);
            }
        }
    }
}

;// CONCATENATED MODULE: ./src/WebSocketTransport.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.




/** @private */
class WebSocketTransport {
    constructor(httpClient, accessTokenFactory, logger, logMessageContent, webSocketConstructor, headers) {
        this._logger = logger;
        this._accessTokenFactory = accessTokenFactory;
        this._logMessageContent = logMessageContent;
        this._webSocketConstructor = webSocketConstructor;
        this._httpClient = httpClient;
        this.onreceive = null;
        this.onclose = null;
        this._headers = headers;
    }
    async connect(url, transferFormat) {
        Arg.isRequired(url, "url");
        Arg.isRequired(transferFormat, "transferFormat");
        Arg.isIn(transferFormat, TransferFormat, "transferFormat");
        this._logger.log(LogLevel.Trace, "(WebSockets transport) Connecting.");
        if (this._accessTokenFactory) {
            const token = await this._accessTokenFactory();
            if (token) {
                url += (url.indexOf("?") < 0 ? "?" : "&") + `access_token=${encodeURIComponent(token)}`;
            }
        }
        return new Promise((resolve, reject) => {
            url = url.replace(/^http/, "ws");
            let webSocket;
            const cookies = this._httpClient.getCookieString(url);
            let opened = false;
            if (Platform.isNode) {
                const headers = {};
                const [name, value] = getUserAgentHeader();
                headers[name] = value;
                if (cookies) {
                    headers[HeaderNames.Cookie] = `${cookies}`;
                }
                // Only pass headers when in non-browser environments
                webSocket = new this._webSocketConstructor(url, undefined, {
                    headers: { ...headers, ...this._headers },
                });
            }
            if (!webSocket) {
                // Chrome is not happy with passing 'undefined' as protocol
                webSocket = new this._webSocketConstructor(url);
            }
            if (transferFormat === TransferFormat.Binary) {
                webSocket.binaryType = "arraybuffer";
            }
            webSocket.onopen = (_event) => {
                this._logger.log(LogLevel.Information, `WebSocket connected to ${url}.`);
                this._webSocket = webSocket;
                opened = true;
                resolve();
            };
            webSocket.onerror = (event) => {
                let error = null;
                // ErrorEvent is a browser only type we need to check if the type exists before using it
                if (typeof ErrorEvent !== "undefined" && event instanceof ErrorEvent) {
                    error = event.error;
                }
                else {
                    error = "There was an error with the transport";
                }
                this._logger.log(LogLevel.Information, `(WebSockets transport) ${error}.`);
            };
            webSocket.onmessage = (message) => {
                this._logger.log(LogLevel.Trace, `(WebSockets transport) data received. ${getDataDetail(message.data, this._logMessageContent)}.`);
                if (this.onreceive) {
                    try {
                        this.onreceive(message.data);
                    }
                    catch (error) {
                        this._close(error);
                        return;
                    }
                }
            };
            webSocket.onclose = (event) => {
                // Don't call close handler if connection was never established
                // We'll reject the connect call instead
                if (opened) {
                    this._close(event);
                }
                else {
                    let error = null;
                    // ErrorEvent is a browser only type we need to check if the type exists before using it
                    if (typeof ErrorEvent !== "undefined" && event instanceof ErrorEvent) {
                        error = event.error;
                    }
                    else {
                        error = "WebSocket failed to connect. The connection could not be found on the server,"
                            + " either the endpoint may not be a SignalR endpoint,"
                            + " the connection ID is not present on the server, or there is a proxy blocking WebSockets."
                            + " If you have multiple servers check that sticky sessions are enabled.";
                    }
                    reject(new Error(error));
                }
            };
        });
    }
    send(data) {
        if (this._webSocket && this._webSocket.readyState === this._webSocketConstructor.OPEN) {
            this._logger.log(LogLevel.Trace, `(WebSockets transport) sending data. ${getDataDetail(data, this._logMessageContent)}.`);
            this._webSocket.send(data);
            return Promise.resolve();
        }
        return Promise.reject("WebSocket is not in the OPEN state");
    }
    stop() {
        if (this._webSocket) {
            // Manually invoke onclose callback inline so we know the HttpConnection was closed properly before returning
            // This also solves an issue where websocket.onclose could take 18+ seconds to trigger during network disconnects
            this._close(undefined);
        }
        return Promise.resolve();
    }
    _close(event) {
        // webSocket will be null if the transport did not start successfully
        if (this._webSocket) {
            // Clear websocket handlers because we are considering the socket closed now
            this._webSocket.onclose = () => { };
            this._webSocket.onmessage = () => { };
            this._webSocket.onerror = () => { };
            this._webSocket.close();
            this._webSocket = undefined;
        }
        this._logger.log(LogLevel.Trace, "(WebSockets transport) socket closed.");
        if (this.onclose) {
            if (this._isCloseEvent(event) && (event.wasClean === false || event.code !== 1000)) {
                this.onclose(new Error(`WebSocket closed with status code: ${event.code} (${event.reason || "no reason given"}).`));
            }
            else if (event instanceof Error) {
                this.onclose(event);
            }
            else {
                this.onclose();
            }
        }
    }
    _isCloseEvent(event) {
        return event && typeof event.wasClean === "boolean" && typeof event.code === "number";
    }
}

;// CONCATENATED MODULE: ./src/HttpConnection.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.









const MAX_REDIRECTS = 100;
/** @private */
class HttpConnection {
    constructor(url, options = {}) {
        this._stopPromiseResolver = () => { };
        this.features = {};
        this._negotiateVersion = 1;
        Arg.isRequired(url, "url");
        this._logger = createLogger(options.logger);
        this.baseUrl = this._resolveUrl(url);
        options = options || {};
        options.logMessageContent = options.logMessageContent === undefined ? false : options.logMessageContent;
        if (typeof options.withCredentials === "boolean" || options.withCredentials === undefined) {
            options.withCredentials = options.withCredentials === undefined ? true : options.withCredentials;
        }
        else {
            throw new Error("withCredentials option was not a 'boolean' or 'undefined' value");
        }
        options.timeout = options.timeout === undefined ? 100 * 1000 : options.timeout;
        let webSocketModule = null;
        let eventSourceModule = null;
        if (Platform.isNode && "function" !== "undefined") {
            // In order to ignore the dynamic require in webpack builds we need to do this magic
            // @ts-ignore: TS doesn't know about these names
            const requireFunc =  true ? require : 0;
            webSocketModule = requireFunc("ws");
            eventSourceModule = requireFunc("eventsource");
        }
        if (!Platform.isNode && typeof WebSocket !== "undefined" && !options.WebSocket) {
            options.WebSocket = WebSocket;
        }
        else if (Platform.isNode && !options.WebSocket) {
            if (webSocketModule) {
                options.WebSocket = webSocketModule;
            }
        }
        if (!Platform.isNode && typeof EventSource !== "undefined" && !options.EventSource) {
            options.EventSource = EventSource;
        }
        else if (Platform.isNode && !options.EventSource) {
            if (typeof eventSourceModule !== "undefined") {
                options.EventSource = eventSourceModule;
            }
        }
        this._httpClient = options.httpClient || new DefaultHttpClient(this._logger);
        this._connectionState = "Disconnected" /* Disconnected */;
        this._connectionStarted = false;
        this._options = options;
        this.onreceive = null;
        this.onclose = null;
    }
    async start(transferFormat) {
        transferFormat = transferFormat || TransferFormat.Binary;
        Arg.isIn(transferFormat, TransferFormat, "transferFormat");
        this._logger.log(LogLevel.Debug, `Starting connection with transfer format '${TransferFormat[transferFormat]}'.`);
        if (this._connectionState !== "Disconnected" /* Disconnected */) {
            return Promise.reject(new Error("Cannot start an HttpConnection that is not in the 'Disconnected' state."));
        }
        this._connectionState = "Connecting" /* Connecting */;
        this._startInternalPromise = this._startInternal(transferFormat);
        await this._startInternalPromise;
        // The TypeScript compiler thinks that connectionState must be Connecting here. The TypeScript compiler is wrong.
        if (this._connectionState === "Disconnecting" /* Disconnecting */) {
            // stop() was called and transitioned the client into the Disconnecting state.
            const message = "Failed to start the HttpConnection before stop() was called.";
            this._logger.log(LogLevel.Error, message);
            // We cannot await stopPromise inside startInternal since stopInternal awaits the startInternalPromise.
            await this._stopPromise;
            return Promise.reject(new Error(message));
        }
        else if (this._connectionState !== "Connected" /* Connected */) {
            // stop() was called and transitioned the client into the Disconnecting state.
            const message = "HttpConnection.startInternal completed gracefully but didn't enter the connection into the connected state!";
            this._logger.log(LogLevel.Error, message);
            return Promise.reject(new Error(message));
        }
        this._connectionStarted = true;
    }
    send(data) {
        if (this._connectionState !== "Connected" /* Connected */) {
            return Promise.reject(new Error("Cannot send data if the connection is not in the 'Connected' State."));
        }
        if (!this._sendQueue) {
            this._sendQueue = new TransportSendQueue(this.transport);
        }
        // Transport will not be null if state is connected
        return this._sendQueue.send(data);
    }
    async stop(error) {
        if (this._connectionState === "Disconnected" /* Disconnected */) {
            this._logger.log(LogLevel.Debug, `Call to HttpConnection.stop(${error}) ignored because the connection is already in the disconnected state.`);
            return Promise.resolve();
        }
        if (this._connectionState === "Disconnecting" /* Disconnecting */) {
            this._logger.log(LogLevel.Debug, `Call to HttpConnection.stop(${error}) ignored because the connection is already in the disconnecting state.`);
            return this._stopPromise;
        }
        this._connectionState = "Disconnecting" /* Disconnecting */;
        this._stopPromise = new Promise((resolve) => {
            // Don't complete stop() until stopConnection() completes.
            this._stopPromiseResolver = resolve;
        });
        // stopInternal should never throw so just observe it.
        await this._stopInternal(error);
        await this._stopPromise;
    }
    async _stopInternal(error) {
        // Set error as soon as possible otherwise there is a race between
        // the transport closing and providing an error and the error from a close message
        // We would prefer the close message error.
        this._stopError = error;
        try {
            await this._startInternalPromise;
        }
        catch (e) {
            // This exception is returned to the user as a rejected Promise from the start method.
        }
        // The transport's onclose will trigger stopConnection which will run our onclose event.
        // The transport should always be set if currently connected. If it wasn't set, it's likely because
        // stop was called during start() and start() failed.
        if (this.transport) {
            try {
                await this.transport.stop();
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `HttpConnection.transport.stop() threw error '${e}'.`);
                this._stopConnection();
            }
            this.transport = undefined;
        }
        else {
            this._logger.log(LogLevel.Debug, "HttpConnection.transport is undefined in HttpConnection.stop() because start() failed.");
        }
    }
    async _startInternal(transferFormat) {
        // Store the original base url and the access token factory since they may change
        // as part of negotiating
        let url = this.baseUrl;
        this._accessTokenFactory = this._options.accessTokenFactory;
        try {
            if (this._options.skipNegotiation) {
                if (this._options.transport === HttpTransportType.WebSockets) {
                    // No need to add a connection ID in this case
                    this.transport = this._constructTransport(HttpTransportType.WebSockets);
                    // We should just call connect directly in this case.
                    // No fallback or negotiate in this case.
                    await this._startTransport(url, transferFormat);
                }
                else {
                    throw new Error("Negotiation can only be skipped when using the WebSocket transport directly.");
                }
            }
            else {
                let negotiateResponse = null;
                let redirects = 0;
                do {
                    negotiateResponse = await this._getNegotiationResponse(url);
                    // the user tries to stop the connection when it is being started
                    if (this._connectionState === "Disconnecting" /* Disconnecting */ || this._connectionState === "Disconnected" /* Disconnected */) {
                        throw new Error("The connection was stopped during negotiation.");
                    }
                    if (negotiateResponse.error) {
                        throw new Error(negotiateResponse.error);
                    }
                    if (negotiateResponse.ProtocolVersion) {
                        throw new Error("Detected a connection attempt to an ASP.NET SignalR Server. This client only supports connecting to an ASP.NET Core SignalR Server. See https://aka.ms/signalr-core-differences for details.");
                    }
                    if (negotiateResponse.url) {
                        url = negotiateResponse.url;
                    }
                    if (negotiateResponse.accessToken) {
                        // Replace the current access token factory with one that uses
                        // the returned access token
                        const accessToken = negotiateResponse.accessToken;
                        this._accessTokenFactory = () => accessToken;
                    }
                    redirects++;
                } while (negotiateResponse.url && redirects < MAX_REDIRECTS);
                if (redirects === MAX_REDIRECTS && negotiateResponse.url) {
                    throw new Error("Negotiate redirection limit exceeded.");
                }
                await this._createTransport(url, this._options.transport, negotiateResponse, transferFormat);
            }
            if (this.transport instanceof LongPollingTransport) {
                this.features.inherentKeepAlive = true;
            }
            if (this._connectionState === "Connecting" /* Connecting */) {
                // Ensure the connection transitions to the connected state prior to completing this.startInternalPromise.
                // start() will handle the case when stop was called and startInternal exits still in the disconnecting state.
                this._logger.log(LogLevel.Debug, "The HttpConnection connected successfully.");
                this._connectionState = "Connected" /* Connected */;
            }
            // stop() is waiting on us via this.startInternalPromise so keep this.transport around so it can clean up.
            // This is the only case startInternal can exit in neither the connected nor disconnected state because stopConnection()
            // will transition to the disconnected state. start() will wait for the transition using the stopPromise.
        }
        catch (e) {
            this._logger.log(LogLevel.Error, "Failed to start the connection: " + e);
            this._connectionState = "Disconnected" /* Disconnected */;
            this.transport = undefined;
            // if start fails, any active calls to stop assume that start will complete the stop promise
            this._stopPromiseResolver();
            return Promise.reject(e);
        }
    }
    async _getNegotiationResponse(url) {
        const headers = {};
        if (this._accessTokenFactory) {
            const token = await this._accessTokenFactory();
            if (token) {
                headers[HeaderNames.Authorization] = `Bearer ${token}`;
            }
        }
        const [name, value] = getUserAgentHeader();
        headers[name] = value;
        const negotiateUrl = this._resolveNegotiateUrl(url);
        this._logger.log(LogLevel.Debug, `Sending negotiation request: ${negotiateUrl}.`);
        try {
            const response = await this._httpClient.post(negotiateUrl, {
                content: "",
                headers: { ...headers, ...this._options.headers },
                timeout: this._options.timeout,
                withCredentials: this._options.withCredentials,
            });
            if (response.statusCode !== 200) {
                return Promise.reject(new Error(`Unexpected status code returned from negotiate '${response.statusCode}'`));
            }
            const negotiateResponse = JSON.parse(response.content);
            if (!negotiateResponse.negotiateVersion || negotiateResponse.negotiateVersion < 1) {
                // Negotiate version 0 doesn't use connectionToken
                // So we set it equal to connectionId so all our logic can use connectionToken without being aware of the negotiate version
                negotiateResponse.connectionToken = negotiateResponse.connectionId;
            }
            return negotiateResponse;
        }
        catch (e) {
            let errorMessage = "Failed to complete negotiation with the server: " + e;
            if (e instanceof HttpError) {
                if (e.statusCode === 404) {
                    errorMessage = errorMessage + " Either this is not a SignalR endpoint or there is a proxy blocking the connection.";
                }
            }
            this._logger.log(LogLevel.Error, errorMessage);
            return Promise.reject(new FailedToNegotiateWithServerError(errorMessage));
        }
    }
    _createConnectUrl(url, connectionToken) {
        if (!connectionToken) {
            return url;
        }
        return url + (url.indexOf("?") === -1 ? "?" : "&") + `id=${connectionToken}`;
    }
    async _createTransport(url, requestedTransport, negotiateResponse, requestedTransferFormat) {
        let connectUrl = this._createConnectUrl(url, negotiateResponse.connectionToken);
        if (this._isITransport(requestedTransport)) {
            this._logger.log(LogLevel.Debug, "Connection was provided an instance of ITransport, using that directly.");
            this.transport = requestedTransport;
            await this._startTransport(connectUrl, requestedTransferFormat);
            this.connectionId = negotiateResponse.connectionId;
            return;
        }
        const transportExceptions = [];
        const transports = negotiateResponse.availableTransports || [];
        let negotiate = negotiateResponse;
        for (const endpoint of transports) {
            const transportOrError = this._resolveTransportOrError(endpoint, requestedTransport, requestedTransferFormat);
            if (transportOrError instanceof Error) {
                // Store the error and continue, we don't want to cause a re-negotiate in these cases
                transportExceptions.push(`${endpoint.transport} failed:`);
                transportExceptions.push(transportOrError);
            }
            else if (this._isITransport(transportOrError)) {
                this.transport = transportOrError;
                if (!negotiate) {
                    try {
                        negotiate = await this._getNegotiationResponse(url);
                    }
                    catch (ex) {
                        return Promise.reject(ex);
                    }
                    connectUrl = this._createConnectUrl(url, negotiate.connectionToken);
                }
                try {
                    await this._startTransport(connectUrl, requestedTransferFormat);
                    this.connectionId = negotiate.connectionId;
                    return;
                }
                catch (ex) {
                    this._logger.log(LogLevel.Error, `Failed to start the transport '${endpoint.transport}': ${ex}`);
                    negotiate = undefined;
                    transportExceptions.push(new FailedToStartTransportError(`${endpoint.transport} failed: ${ex}`, HttpTransportType[endpoint.transport]));
                    if (this._connectionState !== "Connecting" /* Connecting */) {
                        const message = "Failed to select transport before stop() was called.";
                        this._logger.log(LogLevel.Debug, message);
                        return Promise.reject(new Error(message));
                    }
                }
            }
        }
        if (transportExceptions.length > 0) {
            return Promise.reject(new AggregateErrors(`Unable to connect to the server with any of the available transports. ${transportExceptions.join(" ")}`, transportExceptions));
        }
        return Promise.reject(new Error("None of the transports supported by the client are supported by the server."));
    }
    _constructTransport(transport) {
        switch (transport) {
            case HttpTransportType.WebSockets:
                if (!this._options.WebSocket) {
                    throw new Error("'WebSocket' is not supported in your environment.");
                }
                return new WebSocketTransport(this._httpClient, this._accessTokenFactory, this._logger, this._options.logMessageContent, this._options.WebSocket, this._options.headers || {});
            case HttpTransportType.ServerSentEvents:
                if (!this._options.EventSource) {
                    throw new Error("'EventSource' is not supported in your environment.");
                }
                return new ServerSentEventsTransport(this._httpClient, this._accessTokenFactory, this._logger, this._options);
            case HttpTransportType.LongPolling:
                return new LongPollingTransport(this._httpClient, this._accessTokenFactory, this._logger, this._options);
            default:
                throw new Error(`Unknown transport: ${transport}.`);
        }
    }
    _startTransport(url, transferFormat) {
        this.transport.onreceive = this.onreceive;
        this.transport.onclose = (e) => this._stopConnection(e);
        return this.transport.connect(url, transferFormat);
    }
    _resolveTransportOrError(endpoint, requestedTransport, requestedTransferFormat) {
        const transport = HttpTransportType[endpoint.transport];
        if (transport === null || transport === undefined) {
            this._logger.log(LogLevel.Debug, `Skipping transport '${endpoint.transport}' because it is not supported by this client.`);
            return new Error(`Skipping transport '${endpoint.transport}' because it is not supported by this client.`);
        }
        else {
            if (transportMatches(requestedTransport, transport)) {
                const transferFormats = endpoint.transferFormats.map((s) => TransferFormat[s]);
                if (transferFormats.indexOf(requestedTransferFormat) >= 0) {
                    if ((transport === HttpTransportType.WebSockets && !this._options.WebSocket) ||
                        (transport === HttpTransportType.ServerSentEvents && !this._options.EventSource)) {
                        this._logger.log(LogLevel.Debug, `Skipping transport '${HttpTransportType[transport]}' because it is not supported in your environment.'`);
                        return new UnsupportedTransportError(`'${HttpTransportType[transport]}' is not supported in your environment.`, transport);
                    }
                    else {
                        this._logger.log(LogLevel.Debug, `Selecting transport '${HttpTransportType[transport]}'.`);
                        try {
                            return this._constructTransport(transport);
                        }
                        catch (ex) {
                            return ex;
                        }
                    }
                }
                else {
                    this._logger.log(LogLevel.Debug, `Skipping transport '${HttpTransportType[transport]}' because it does not support the requested transfer format '${TransferFormat[requestedTransferFormat]}'.`);
                    return new Error(`'${HttpTransportType[transport]}' does not support ${TransferFormat[requestedTransferFormat]}.`);
                }
            }
            else {
                this._logger.log(LogLevel.Debug, `Skipping transport '${HttpTransportType[transport]}' because it was disabled by the client.`);
                return new DisabledTransportError(`'${HttpTransportType[transport]}' is disabled by the client.`, transport);
            }
        }
    }
    _isITransport(transport) {
        return transport && typeof (transport) === "object" && "connect" in transport;
    }
    _stopConnection(error) {
        this._logger.log(LogLevel.Debug, `HttpConnection.stopConnection(${error}) called while in state ${this._connectionState}.`);
        this.transport = undefined;
        // If we have a stopError, it takes precedence over the error from the transport
        error = this._stopError || error;
        this._stopError = undefined;
        if (this._connectionState === "Disconnected" /* Disconnected */) {
            this._logger.log(LogLevel.Debug, `Call to HttpConnection.stopConnection(${error}) was ignored because the connection is already in the disconnected state.`);
            return;
        }
        if (this._connectionState === "Connecting" /* Connecting */) {
            this._logger.log(LogLevel.Warning, `Call to HttpConnection.stopConnection(${error}) was ignored because the connection is still in the connecting state.`);
            throw new Error(`HttpConnection.stopConnection(${error}) was called while the connection is still in the connecting state.`);
        }
        if (this._connectionState === "Disconnecting" /* Disconnecting */) {
            // A call to stop() induced this call to stopConnection and needs to be completed.
            // Any stop() awaiters will be scheduled to continue after the onclose callback fires.
            this._stopPromiseResolver();
        }
        if (error) {
            this._logger.log(LogLevel.Error, `Connection disconnected with error '${error}'.`);
        }
        else {
            this._logger.log(LogLevel.Information, "Connection disconnected.");
        }
        if (this._sendQueue) {
            this._sendQueue.stop().catch((e) => {
                this._logger.log(LogLevel.Error, `TransportSendQueue.stop() threw error '${e}'.`);
            });
            this._sendQueue = undefined;
        }
        this.connectionId = undefined;
        this._connectionState = "Disconnected" /* Disconnected */;
        if (this._connectionStarted) {
            this._connectionStarted = false;
            try {
                if (this.onclose) {
                    this.onclose(error);
                }
            }
            catch (e) {
                this._logger.log(LogLevel.Error, `HttpConnection.onclose(${error}) threw error '${e}'.`);
            }
        }
    }
    _resolveUrl(url) {
        // startsWith is not supported in IE
        if (url.lastIndexOf("https://", 0) === 0 || url.lastIndexOf("http://", 0) === 0) {
            return url;
        }
        if (!Platform.isBrowser) {
            throw new Error(`Cannot resolve '${url}'.`);
        }
        // Setting the url to the href propery of an anchor tag handles normalization
        // for us. There are 3 main cases.
        // 1. Relative path normalization e.g "b" -> "http://localhost:5000/a/b"
        // 2. Absolute path normalization e.g "/a/b" -> "http://localhost:5000/a/b"
        // 3. Networkpath reference normalization e.g "//localhost:5000/a/b" -> "http://localhost:5000/a/b"
        const aTag = window.document.createElement("a");
        aTag.href = url;
        this._logger.log(LogLevel.Information, `Normalizing '${url}' to '${aTag.href}'.`);
        return aTag.href;
    }
    _resolveNegotiateUrl(url) {
        const index = url.indexOf("?");
        let negotiateUrl = url.substring(0, index === -1 ? url.length : index);
        if (negotiateUrl[negotiateUrl.length - 1] !== "/") {
            negotiateUrl += "/";
        }
        negotiateUrl += "negotiate";
        negotiateUrl += index === -1 ? "" : url.substring(index);
        if (negotiateUrl.indexOf("negotiateVersion") === -1) {
            negotiateUrl += index === -1 ? "?" : "&";
            negotiateUrl += "negotiateVersion=" + this._negotiateVersion;
        }
        return negotiateUrl;
    }
}
function transportMatches(requestedTransport, actualTransport) {
    return !requestedTransport || ((actualTransport & requestedTransport) !== 0);
}
/** @private */
class TransportSendQueue {
    constructor(_transport) {
        this._transport = _transport;
        this._buffer = [];
        this._executing = true;
        this._sendBufferedData = new PromiseSource();
        this._transportResult = new PromiseSource();
        this._sendLoopPromise = this._sendLoop();
    }
    send(data) {
        this._bufferData(data);
        if (!this._transportResult) {
            this._transportResult = new PromiseSource();
        }
        return this._transportResult.promise;
    }
    stop() {
        this._executing = false;
        this._sendBufferedData.resolve();
        return this._sendLoopPromise;
    }
    _bufferData(data) {
        if (this._buffer.length && typeof (this._buffer[0]) !== typeof (data)) {
            throw new Error(`Expected data to be of type ${typeof (this._buffer)} but was of type ${typeof (data)}`);
        }
        this._buffer.push(data);
        this._sendBufferedData.resolve();
    }
    async _sendLoop() {
        while (true) {
            await this._sendBufferedData.promise;
            if (!this._executing) {
                if (this._transportResult) {
                    this._transportResult.reject("Connection stopped.");
                }
                break;
            }
            this._sendBufferedData = new PromiseSource();
            const transportResult = this._transportResult;
            this._transportResult = undefined;
            const data = typeof (this._buffer[0]) === "string" ?
                this._buffer.join("") :
                TransportSendQueue._concatBuffers(this._buffer);
            this._buffer.length = 0;
            try {
                await this._transport.send(data);
                transportResult.resolve();
            }
            catch (error) {
                transportResult.reject(error);
            }
        }
    }
    static _concatBuffers(arrayBuffers) {
        const totalLength = arrayBuffers.map((b) => b.byteLength).reduce((a, b) => a + b);
        const result = new Uint8Array(totalLength);
        let offset = 0;
        for (const item of arrayBuffers) {
            result.set(new Uint8Array(item), offset);
            offset += item.byteLength;
        }
        return result.buffer;
    }
}
class PromiseSource {
    constructor() {
        this.promise = new Promise((resolve, reject) => [this._resolver, this._rejecter] = [resolve, reject]);
    }
    resolve() {
        this._resolver();
    }
    reject(reason) {
        this._rejecter(reason);
    }
}

;// CONCATENATED MODULE: ./src/JsonHubProtocol.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.





const JSON_HUB_PROTOCOL_NAME = "json";
/** Implements the JSON Hub Protocol. */
class JsonHubProtocol {
    constructor() {
        /** @inheritDoc */
        this.name = JSON_HUB_PROTOCOL_NAME;
        /** @inheritDoc */
        this.version = 1;
        /** @inheritDoc */
        this.transferFormat = TransferFormat.Text;
    }
    /** Creates an array of {@link @microsoft/signalr.HubMessage} objects from the specified serialized representation.
     *
     * @param {string} input A string containing the serialized representation.
     * @param {ILogger} logger A logger that will be used to log messages that occur during parsing.
     */
    parseMessages(input, logger) {
        // The interface does allow "ArrayBuffer" to be passed in, but this implementation does not. So let's throw a useful error.
        if (typeof input !== "string") {
            throw new Error("Invalid input for JSON hub protocol. Expected a string.");
        }
        if (!input) {
            return [];
        }
        if (logger === null) {
            logger = NullLogger.instance;
        }
        // Parse the messages
        const messages = TextMessageFormat.parse(input);
        const hubMessages = [];
        for (const message of messages) {
            const parsedMessage = JSON.parse(message);
            if (typeof parsedMessage.type !== "number") {
                throw new Error("Invalid payload.");
            }
            switch (parsedMessage.type) {
                case MessageType.Invocation:
                    this._isInvocationMessage(parsedMessage);
                    break;
                case MessageType.StreamItem:
                    this._isStreamItemMessage(parsedMessage);
                    break;
                case MessageType.Completion:
                    this._isCompletionMessage(parsedMessage);
                    break;
                case MessageType.Ping:
                    // Single value, no need to validate
                    break;
                case MessageType.Close:
                    // All optional values, no need to validate
                    break;
                default:
                    // Future protocol changes can add message types, old clients can ignore them
                    logger.log(LogLevel.Information, "Unknown message type '" + parsedMessage.type + "' ignored.");
                    continue;
            }
            hubMessages.push(parsedMessage);
        }
        return hubMessages;
    }
    /** Writes the specified {@link @microsoft/signalr.HubMessage} to a string and returns it.
     *
     * @param {HubMessage} message The message to write.
     * @returns {string} A string containing the serialized representation of the message.
     */
    writeMessage(message) {
        return TextMessageFormat.write(JSON.stringify(message));
    }
    _isInvocationMessage(message) {
        this._assertNotEmptyString(message.target, "Invalid payload for Invocation message.");
        if (message.invocationId !== undefined) {
            this._assertNotEmptyString(message.invocationId, "Invalid payload for Invocation message.");
        }
    }
    _isStreamItemMessage(message) {
        this._assertNotEmptyString(message.invocationId, "Invalid payload for StreamItem message.");
        if (message.item === undefined) {
            throw new Error("Invalid payload for StreamItem message.");
        }
    }
    _isCompletionMessage(message) {
        if (message.result && message.error) {
            throw new Error("Invalid payload for Completion message.");
        }
        if (!message.result && message.error) {
            this._assertNotEmptyString(message.error, "Invalid payload for Completion message.");
        }
        this._assertNotEmptyString(message.invocationId, "Invalid payload for Completion message.");
    }
    _assertNotEmptyString(value, errorMessage) {
        if (typeof value !== "string" || value === "") {
            throw new Error(errorMessage);
        }
    }
}

;// CONCATENATED MODULE: ./src/HubConnectionBuilder.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.







const LogLevelNameMapping = {
    trace: LogLevel.Trace,
    debug: LogLevel.Debug,
    info: LogLevel.Information,
    information: LogLevel.Information,
    warn: LogLevel.Warning,
    warning: LogLevel.Warning,
    error: LogLevel.Error,
    critical: LogLevel.Critical,
    none: LogLevel.None,
};
function parseLogLevel(name) {
    // Case-insensitive matching via lower-casing
    // Yes, I know case-folding is a complicated problem in Unicode, but we only support
    // the ASCII strings defined in LogLevelNameMapping anyway, so it's fine -anurse.
    const mapping = LogLevelNameMapping[name.toLowerCase()];
    if (typeof mapping !== "undefined") {
        return mapping;
    }
    else {
        throw new Error(`Unknown log level: ${name}`);
    }
}
/** A builder for configuring {@link @microsoft/signalr.HubConnection} instances. */
class HubConnectionBuilder {
    configureLogging(logging) {
        Arg.isRequired(logging, "logging");
        if (isLogger(logging)) {
            this.logger = logging;
        }
        else if (typeof logging === "string") {
            const logLevel = parseLogLevel(logging);
            this.logger = new ConsoleLogger(logLevel);
        }
        else {
            this.logger = new ConsoleLogger(logging);
        }
        return this;
    }
    withUrl(url, transportTypeOrOptions) {
        Arg.isRequired(url, "url");
        Arg.isNotEmpty(url, "url");
        this.url = url;
        // Flow-typing knows where it's at. Since HttpTransportType is a number and IHttpConnectionOptions is guaranteed
        // to be an object, we know (as does TypeScript) this comparison is all we need to figure out which overload was called.
        if (typeof transportTypeOrOptions === "object") {
            this.httpConnectionOptions = { ...this.httpConnectionOptions, ...transportTypeOrOptions };
        }
        else {
            this.httpConnectionOptions = {
                ...this.httpConnectionOptions,
                transport: transportTypeOrOptions,
            };
        }
        return this;
    }
    /** Configures the {@link @microsoft/signalr.HubConnection} to use the specified Hub Protocol.
     *
     * @param {IHubProtocol} protocol The {@link @microsoft/signalr.IHubProtocol} implementation to use.
     */
    withHubProtocol(protocol) {
        Arg.isRequired(protocol, "protocol");
        this.protocol = protocol;
        return this;
    }
    withAutomaticReconnect(retryDelaysOrReconnectPolicy) {
        if (this.reconnectPolicy) {
            throw new Error("A reconnectPolicy has already been set.");
        }
        if (!retryDelaysOrReconnectPolicy) {
            this.reconnectPolicy = new DefaultReconnectPolicy();
        }
        else if (Array.isArray(retryDelaysOrReconnectPolicy)) {
            this.reconnectPolicy = new DefaultReconnectPolicy(retryDelaysOrReconnectPolicy);
        }
        else {
            this.reconnectPolicy = retryDelaysOrReconnectPolicy;
        }
        return this;
    }
    /** Creates a {@link @microsoft/signalr.HubConnection} from the configuration options specified in this builder.
     *
     * @returns {HubConnection} The configured {@link @microsoft/signalr.HubConnection}.
     */
    build() {
        // If httpConnectionOptions has a logger, use it. Otherwise, override it with the one
        // provided to configureLogger
        const httpConnectionOptions = this.httpConnectionOptions || {};
        // If it's 'null', the user **explicitly** asked for null, don't mess with it.
        if (httpConnectionOptions.logger === undefined) {
            // If our logger is undefined or null, that's OK, the HttpConnection constructor will handle it.
            httpConnectionOptions.logger = this.logger;
        }
        // Now create the connection
        if (!this.url) {
            throw new Error("The 'HubConnectionBuilder.withUrl' method must be called before building the connection.");
        }
        const connection = new HttpConnection(this.url, httpConnectionOptions);
        return HubConnection.create(connection, this.logger || NullLogger.instance, this.protocol || new JsonHubProtocol(), this.reconnectPolicy);
    }
}
function isLogger(logger) {
    return logger.log !== undefined;
}

;// CONCATENATED MODULE: ./src/index.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.













;// CONCATENATED MODULE: ./src/browser-index.ts
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// This is where we add any polyfills we'll need for the browser. It is the entry module for browser-specific builds.
// Copy from Array.prototype into Uint8Array to polyfill on IE. It's OK because the implementations of indexOf and slice use properties
// that exist on Uint8Array with the same name, and JavaScript is magic.
// We make them 'writable' because the Buffer polyfill messes with it as well.
if (!Uint8Array.prototype.indexOf) {
    Object.defineProperty(Uint8Array.prototype, "indexOf", {
        value: Array.prototype.indexOf,
        writable: true,
    });
}
if (!Uint8Array.prototype.slice) {
    Object.defineProperty(Uint8Array.prototype, "slice", {
        // wrap the slice in Uint8Array so it looks like a Uint8Array.slice call
        // eslint-disable-next-line object-shorthand
        value: function (start, end) { return new Uint8Array(Array.prototype.slice.call(this, start, end)); },
        writable: true,
    });
}
if (!Uint8Array.prototype.forEach) {
    Object.defineProperty(Uint8Array.prototype, "forEach", {
        value: Array.prototype.forEach,
        writable: true,
    });
}


/******/ 	return __webpack_exports__;
/******/ })()
;
});
//# sourceMappingURL=signalr.js.map
var t,e;t=self,e=function(){return(()=>{var t={d:(e,s)=>{for(var n in s)t.o(s,n)&&!t.o(e,n)&&Object.defineProperty(e,n,{enumerable:!0,get:s[n]})}};t.g=function(){if("object"==typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(t){if("object"==typeof window)return window}}(),t.o=(t,e)=>Object.prototype.hasOwnProperty.call(t,e),t.r=t=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"t",{value:!0})};var e,s={};t.r(s),t.d(s,{AbortError:()=>r,DefaultHttpClient:()=>H,HttpClient:()=>d,HttpError:()=>n,HttpResponse:()=>u,HttpTransportType:()=>M,HubConnection:()=>N,HubConnectionBuilder:()=>Q,HubConnectionState:()=>R,JsonHubProtocol:()=>G,LogLevel:()=>e,MessageType:()=>A,NullLogger:()=>f,Subject:()=>U,TimeoutError:()=>i,TransferFormat:()=>W,VERSION:()=>p});class n extends Error{constructor(t,e){const s=new.target.prototype;super(`${t}: Status code '${e}'`),this.statusCode=e,this.__proto__=s}}class i extends Error{constructor(t="A timeout occurred."){const e=new.target.prototype;super(t),this.__proto__=e}}class r extends Error{constructor(t="An abort occurred."){const e=new.target.prototype;super(t),this.__proto__=e}}class o extends Error{constructor(t,e){const s=new.target.prototype;super(t),this.transport=e,this.errorType="UnsupportedTransportError",this.__proto__=s}}class h extends Error{constructor(t,e){const s=new.target.prototype;super(t),this.transport=e,this.errorType="DisabledTransportError",this.__proto__=s}}class c extends Error{constructor(t,e){const s=new.target.prototype;super(t),this.transport=e,this.errorType="FailedToStartTransportError",this.__proto__=s}}class a extends Error{constructor(t){const e=new.target.prototype;super(t),this.errorType="FailedToNegotiateWithServerError",this.__proto__=e}}class l extends Error{constructor(t,e){const s=new.target.prototype;super(t),this.innerErrors=e,this.__proto__=s}}class u{constructor(t,e,s){this.statusCode=t,this.statusText=e,this.content=s}}class d{get(t,e){return this.send({...e,method:"GET",url:t})}post(t,e){return this.send({...e,method:"POST",url:t})}delete(t,e){return this.send({...e,method:"DELETE",url:t})}getCookieString(t){return""}}!function(t){t[t.Trace=0]="Trace",t[t.Debug=1]="Debug",t[t.Information=2]="Information",t[t.Warning=3]="Warning",t[t.Error=4]="Error",t[t.Critical=5]="Critical",t[t.None=6]="None"}(e||(e={}));class f{constructor(){}log(t,e){}}f.instance=new f;const p="6.0.6";class w{static isRequired(t,e){if(null==t)throw new Error(`The '${e}' argument is required.`)}static isNotEmpty(t,e){if(!t||t.match(/^\s*$/))throw new Error(`The '${e}' argument should not be empty.`)}static isIn(t,e,s){if(!(t in e))throw new Error(`Unknown ${s} value: ${t}.`)}}class g{static get isBrowser(){return"object"==typeof window&&"object"==typeof window.document}static get isWebWorker(){return"object"==typeof self&&"importScripts"in self}static get isReactNative(){return"object"==typeof window&&void 0===window.document}static get isNode(){return!this.isBrowser&&!this.isWebWorker&&!this.isReactNative}}function y(t,e){let s="";return m(t)?(s=`Binary data of length ${t.byteLength}`,e&&(s+=`. Content: '${function(t){const e=new Uint8Array(t);let s="";return e.forEach((t=>{s+=`0x${t<16?"0":""}${t.toString(16)} `})),s.substr(0,s.length-1)}(t)}'`)):"string"==typeof t&&(s=`String data of length ${t.length}`,e&&(s+=`. Content: '${t}'`)),s}function m(t){return t&&"undefined"!=typeof ArrayBuffer&&(t instanceof ArrayBuffer||t.constructor&&"ArrayBuffer"===t.constructor.name)}async function b(t,s,n,i,r,o,h){let c={};if(r){const t=await r();t&&(c={Authorization:`Bearer ${t}`})}const[a,l]=$();c[a]=l,t.log(e.Trace,`(${s} transport) sending data. ${y(o,h.logMessageContent)}.`);const u=m(o)?"arraybuffer":"text",d=await n.post(i,{content:o,headers:{...c,...h.headers},responseType:u,timeout:h.timeout,withCredentials:h.withCredentials});t.log(e.Trace,`(${s} transport) request complete. Response status: ${d.statusCode}.`)}class v{constructor(t,e){this.i=t,this.h=e}dispose(){const t=this.i.observers.indexOf(this.h);t>-1&&this.i.observers.splice(t,1),0===this.i.observers.length&&this.i.cancelCallback&&this.i.cancelCallback().catch((t=>{}))}}class E{constructor(t){this.l=t,this.out=console}log(t,s){if(t>=this.l){const n=`[${(new Date).toISOString()}] ${e[t]}: ${s}`;switch(t){case e.Critical:case e.Error:this.out.error(n);break;case e.Warning:this.out.warn(n);break;case e.Information:this.out.info(n);break;default:this.out.log(n)}}}}function $(){let t="X-SignalR-User-Agent";return g.isNode&&(t="User-Agent"),[t,C(p,S(),g.isNode?"NodeJS":"Browser",k())]}function C(t,e,s,n){let i="Microsoft SignalR/";const r=t.split(".");return i+=`${r[0]}.${r[1]}`,i+=` (${t}; `,i+=e&&""!==e?`${e}; `:"Unknown OS; ",i+=`${s}`,i+=n?`; ${n}`:"; Unknown Runtime Version",i+=")",i}function S(){if(!g.isNode)return"";switch(process.platform){case"win32":return"Windows NT";case"darwin":return"macOS";case"linux":return"Linux";default:return process.platform}}function k(){if(g.isNode)return process.versions.node}function P(t){return t.stack?t.stack:t.message?t.message:`${t}`}class T extends d{constructor(e){if(super(),this.u=e,"undefined"==typeof fetch){const t=require;this.p=new(t("tough-cookie").CookieJar),this.m=t("node-fetch"),this.m=t("fetch-cookie")(this.m,this.p)}else this.m=fetch.bind(function(){if("undefined"!=typeof globalThis)return globalThis;if("undefined"!=typeof self)return self;if("undefined"!=typeof window)return window;if(void 0!==t.g)return t.g;throw new Error("could not find global")}());if("undefined"==typeof AbortController){const t=require;this.v=t("abort-controller")}else this.v=AbortController}async send(t){if(t.abortSignal&&t.abortSignal.aborted)throw new r;if(!t.method)throw new Error("No method defined.");if(!t.url)throw new Error("No url defined.");const s=new this.v;let o;t.abortSignal&&(t.abortSignal.onabort=()=>{s.abort(),o=new r});let h,c=null;if(t.timeout){const n=t.timeout;c=setTimeout((()=>{s.abort(),this.u.log(e.Warning,"Timeout from HTTP request."),o=new i}),n)}try{h=await this.m(t.url,{body:t.content,cache:"no-cache",credentials:!0===t.withCredentials?"include":"same-origin",headers:{"Content-Type":"text/plain;charset=UTF-8","X-Requested-With":"XMLHttpRequest",...t.headers},method:t.method,mode:"cors",redirect:"follow",signal:s.signal})}catch(t){if(o)throw o;throw this.u.log(e.Warning,`Error from HTTP request. ${t}.`),t}finally{c&&clearTimeout(c),t.abortSignal&&(t.abortSignal.onabort=null)}if(!h.ok){const t=await I(h,"text");throw new n(t||h.statusText,h.status)}const a=I(h,t.responseType),l=await a;return new u(h.status,h.statusText,l)}getCookieString(t){let e="";return g.isNode&&this.p&&this.p.getCookies(t,((t,s)=>e=s.join("; "))),e}}function I(t,e){let s;switch(e){case"arraybuffer":s=t.arrayBuffer();break;case"text":s=t.text();break;case"blob":case"document":case"json":throw new Error(`${e} is not supported.`);default:s=t.text()}return s}class _ extends d{constructor(t){super(),this.u=t}send(t){return t.abortSignal&&t.abortSignal.aborted?Promise.reject(new r):t.method?t.url?new Promise(((s,o)=>{const h=new XMLHttpRequest;h.open(t.method,t.url,!0),h.withCredentials=void 0===t.withCredentials||t.withCredentials,h.setRequestHeader("X-Requested-With","XMLHttpRequest"),h.setRequestHeader("Content-Type","text/plain;charset=UTF-8");const c=t.headers;c&&Object.keys(c).forEach((t=>{h.setRequestHeader(t,c[t])})),t.responseType&&(h.responseType=t.responseType),t.abortSignal&&(t.abortSignal.onabort=()=>{h.abort(),o(new r)}),t.timeout&&(h.timeout=t.timeout),h.onload=()=>{t.abortSignal&&(t.abortSignal.onabort=null),h.status>=200&&h.status<300?s(new u(h.status,h.statusText,h.response||h.responseText)):o(new n(h.response||h.responseText||h.statusText,h.status))},h.onerror=()=>{this.u.log(e.Warning,`Error from HTTP request. ${h.status}: ${h.statusText}.`),o(new n(h.statusText,h.status))},h.ontimeout=()=>{this.u.log(e.Warning,"Timeout from HTTP request."),o(new i)},h.send(t.content||"")})):Promise.reject(new Error("No url defined.")):Promise.reject(new Error("No method defined."))}}class H extends d{constructor(t){if(super(),"undefined"!=typeof fetch||g.isNode)this.$=new T(t);else{if("undefined"==typeof XMLHttpRequest)throw new Error("No usable HttpClient found.");this.$=new _(t)}}send(t){return t.abortSignal&&t.abortSignal.aborted?Promise.reject(new r):t.method?t.url?this.$.send(t):Promise.reject(new Error("No url defined.")):Promise.reject(new Error("No method defined."))}getCookieString(t){return this.$.getCookieString(t)}}class D{static write(t){return`${t}${D.RecordSeparator}`}static parse(t){if(t[t.length-1]!==D.RecordSeparator)throw new Error("Message is incomplete.");const e=t.split(D.RecordSeparator);return e.pop(),e}}D.RecordSeparatorCode=30,D.RecordSeparator=String.fromCharCode(D.RecordSeparatorCode);class x{writeHandshakeRequest(t){return D.write(JSON.stringify(t))}parseHandshakeResponse(t){let e,s;if(m(t)){const n=new Uint8Array(t),i=n.indexOf(D.RecordSeparatorCode);if(-1===i)throw new Error("Message is incomplete.");const r=i+1;e=String.fromCharCode.apply(null,Array.prototype.slice.call(n.slice(0,r))),s=n.byteLength>r?n.slice(r).buffer:null}else{const n=t,i=n.indexOf(D.RecordSeparator);if(-1===i)throw new Error("Message is incomplete.");const r=i+1;e=n.substring(0,r),s=n.length>r?n.substring(r):null}const n=D.parse(e),i=JSON.parse(n[0]);if(i.type)throw new Error("Expected a handshake response from the server.");return[s,i]}}var A,R;!function(t){t[t.Invocation=1]="Invocation",t[t.StreamItem=2]="StreamItem",t[t.Completion=3]="Completion",t[t.StreamInvocation=4]="StreamInvocation",t[t.CancelInvocation=5]="CancelInvocation",t[t.Ping=6]="Ping",t[t.Close=7]="Close"}(A||(A={}));class U{constructor(){this.observers=[]}next(t){for(const e of this.observers)e.next(t)}error(t){for(const e of this.observers)e.error&&e.error(t)}complete(){for(const t of this.observers)t.complete&&t.complete()}subscribe(t){return this.observers.push(t),new v(this,t)}}!function(t){t.Disconnected="Disconnected",t.Connecting="Connecting",t.Connected="Connected",t.Disconnecting="Disconnecting",t.Reconnecting="Reconnecting"}(R||(R={}));class N{constructor(t,s,n,i){this.C=0,this.S=()=>{this.u.log(e.Warning,"The page is being frozen, this will likely lead to the connection being closed and messages being lost. For more information see the docs at https://docs.microsoft.com/aspnet/core/signalr/javascript-client#bsleep")},w.isRequired(t,"connection"),w.isRequired(s,"logger"),w.isRequired(n,"protocol"),this.serverTimeoutInMilliseconds=3e4,this.keepAliveIntervalInMilliseconds=15e3,this.u=s,this.k=n,this.connection=t,this.P=i,this.T=new x,this.connection.onreceive=t=>this.I(t),this.connection.onclose=t=>this._(t),this.H={},this.D={},this.A=[],this.R=[],this.U=[],this.N=0,this.L=!1,this.q=R.Disconnected,this.j=!1,this.M=this.k.writeMessage({type:A.Ping})}static create(t,e,s,n){return new N(t,e,s,n)}get state(){return this.q}get connectionId(){return this.connection&&this.connection.connectionId||null}get baseUrl(){return this.connection.baseUrl||""}set baseUrl(t){if(this.q!==R.Disconnected&&this.q!==R.Reconnecting)throw new Error("The HubConnection must be in the Disconnected or Reconnecting state to change the url.");if(!t)throw new Error("The HubConnection url must be a valid url.");this.connection.baseUrl=t}start(){return this.W=this.O(),this.W}async O(){if(this.q!==R.Disconnected)return Promise.reject(new Error("Cannot start a HubConnection that is not in the 'Disconnected' state."));this.q=R.Connecting,this.u.log(e.Debug,"Starting HubConnection.");try{await this.F(),g.isBrowser&&window.document.addEventListener("freeze",this.S),this.q=R.Connected,this.j=!0,this.u.log(e.Debug,"HubConnection connected successfully.")}catch(t){return this.q=R.Disconnected,this.u.log(e.Debug,`HubConnection failed to start successfully because of error '${t}'.`),Promise.reject(t)}}async F(){this.B=void 0,this.L=!1;const t=new Promise(((t,e)=>{this.X=t,this.J=e}));await this.connection.start(this.k.transferFormat);try{const s={protocol:this.k.name,version:this.k.version};if(this.u.log(e.Debug,"Sending handshake request."),await this.V(this.T.writeHandshakeRequest(s)),this.u.log(e.Information,`Using HubProtocol '${this.k.name}'.`),this.G(),this.K(),this.Y(),await t,this.B)throw this.B}catch(t){throw this.u.log(e.Debug,`Hub handshake failed with error '${t}' during start(). Stopping HubConnection.`),this.G(),this.Z(),await this.connection.stop(t),t}}async stop(){const t=this.W;this.tt=this.et(),await this.tt;try{await t}catch(t){}}et(t){return this.q===R.Disconnected?(this.u.log(e.Debug,`Call to HubConnection.stop(${t}) ignored because it is already in the disconnected state.`),Promise.resolve()):this.q===R.Disconnecting?(this.u.log(e.Debug,`Call to HttpConnection.stop(${t}) ignored because the connection is already in the disconnecting state.`),this.tt):(this.q=R.Disconnecting,this.u.log(e.Debug,"Stopping HubConnection."),this.st?(this.u.log(e.Debug,"Connection stopped during reconnect delay. Done reconnecting."),clearTimeout(this.st),this.st=void 0,this.nt(),Promise.resolve()):(this.G(),this.Z(),this.B=t||new Error("The connection was stopped before the hub handshake could complete."),this.connection.stop(t)))}stream(t,...e){const[s,n]=this.it(e),i=this.rt(t,e,n);let r;const o=new U;return o.cancelCallback=()=>{const t=this.ot(i.invocationId);return delete this.H[i.invocationId],r.then((()=>this.ht(t)))},this.H[i.invocationId]=(t,e)=>{e?o.error(e):t&&(t.type===A.Completion?t.error?o.error(new Error(t.error)):o.complete():o.next(t.item))},r=this.ht(i).catch((t=>{o.error(t),delete this.H[i.invocationId]})),this.ct(s,r),o}V(t){return this.Y(),this.connection.send(t)}ht(t){return this.V(this.k.writeMessage(t))}send(t,...e){const[s,n]=this.it(e),i=this.ht(this.at(t,e,!0,n));return this.ct(s,i),i}invoke(t,...e){const[s,n]=this.it(e),i=this.at(t,e,!1,n);return new Promise(((t,e)=>{this.H[i.invocationId]=(s,n)=>{n?e(n):s&&(s.type===A.Completion?s.error?e(new Error(s.error)):t(s.result):e(new Error(`Unexpected message type: ${s.type}`)))};const n=this.ht(i).catch((t=>{e(t),delete this.H[i.invocationId]}));this.ct(s,n)}))}on(t,e){t&&e&&(t=t.toLowerCase(),this.D[t]||(this.D[t]=[]),-1===this.D[t].indexOf(e)&&this.D[t].push(e))}off(t,e){if(!t)return;t=t.toLowerCase();const s=this.D[t];if(s)if(e){const n=s.indexOf(e);-1!==n&&(s.splice(n,1),0===s.length&&delete this.D[t])}else delete this.D[t]}onclose(t){t&&this.A.push(t)}onreconnecting(t){t&&this.R.push(t)}onreconnected(t){t&&this.U.push(t)}I(t){if(this.G(),this.L||(t=this.lt(t),this.L=!0),t){const s=this.k.parseMessages(t,this.u);for(const t of s)switch(t.type){case A.Invocation:this.ut(t);break;case A.StreamItem:case A.Completion:{const s=this.H[t.invocationId];if(s){t.type===A.Completion&&delete this.H[t.invocationId];try{s(t)}catch(t){this.u.log(e.Error,`Stream callback threw error: ${P(t)}`)}}break}case A.Ping:break;case A.Close:{this.u.log(e.Information,"Close message received from server.");const s=t.error?new Error("Server returned an error on close: "+t.error):void 0;!0===t.allowReconnect?this.connection.stop(s):this.tt=this.et(s);break}default:this.u.log(e.Warning,`Invalid message type: ${t.type}.`)}}this.K()}lt(t){let s,n;try{[n,s]=this.T.parseHandshakeResponse(t)}catch(t){const s="Error parsing handshake response: "+t;this.u.log(e.Error,s);const n=new Error(s);throw this.J(n),n}if(s.error){const t="Server returned handshake error: "+s.error;this.u.log(e.Error,t);const n=new Error(t);throw this.J(n),n}return this.u.log(e.Debug,"Server handshake complete."),this.X(),n}Y(){this.connection.features.inherentKeepAlive||(this.C=(new Date).getTime()+this.keepAliveIntervalInMilliseconds,this.Z())}K(){if(!(this.connection.features&&this.connection.features.inherentKeepAlive||(this.dt=setTimeout((()=>this.serverTimeout()),this.serverTimeoutInMilliseconds),void 0!==this.ft))){let t=this.C-(new Date).getTime();t<0&&(t=0),this.ft=setTimeout((async()=>{if(this.q===R.Connected)try{await this.V(this.M)}catch{this.Z()}}),t)}}serverTimeout(){this.connection.stop(new Error("Server timeout elapsed without receiving a message from the server."))}ut(t){const s=this.D[t.target.toLowerCase()];if(s){try{s.forEach((e=>e.apply(this,t.arguments)))}catch(s){this.u.log(e.Error,`A callback for the method ${t.target.toLowerCase()} threw error '${s}'.`)}if(t.invocationId){const t="Server requested a response, which is not supported in this version of the client.";this.u.log(e.Error,t),this.tt=this.et(new Error(t))}}else this.u.log(e.Warning,`No client method with the name '${t.target}' found.`)}_(t){this.u.log(e.Debug,`HubConnection.connectionClosed(${t}) called while in state ${this.q}.`),this.B=this.B||t||new Error("The underlying connection was closed before the hub handshake could complete."),this.X&&this.X(),this.wt(t||new Error("Invocation canceled due to the underlying connection being closed.")),this.G(),this.Z(),this.q===R.Disconnecting?this.nt(t):this.q===R.Connected&&this.P?this.gt(t):this.q===R.Connected&&this.nt(t)}nt(t){if(this.j){this.q=R.Disconnected,this.j=!1,g.isBrowser&&window.document.removeEventListener("freeze",this.S);try{this.A.forEach((e=>e.apply(this,[t])))}catch(s){this.u.log(e.Error,`An onclose callback called with error '${t}' threw error '${s}'.`)}}}async gt(t){const s=Date.now();let n=0,i=void 0!==t?t:new Error("Attempting to reconnect due to a unknown error."),r=this.yt(n++,0,i);if(null===r)return this.u.log(e.Debug,"Connection not reconnecting because the IRetryPolicy returned null on the first reconnect attempt."),void this.nt(t);if(this.q=R.Reconnecting,t?this.u.log(e.Information,`Connection reconnecting because of error '${t}'.`):this.u.log(e.Information,"Connection reconnecting."),0!==this.R.length){try{this.R.forEach((e=>e.apply(this,[t])))}catch(s){this.u.log(e.Error,`An onreconnecting callback called with error '${t}' threw error '${s}'.`)}if(this.q!==R.Reconnecting)return void this.u.log(e.Debug,"Connection left the reconnecting state in onreconnecting callback. Done reconnecting.")}for(;null!==r;){if(this.u.log(e.Information,`Reconnect attempt number ${n} will start in ${r} ms.`),await new Promise((t=>{this.st=setTimeout(t,r)})),this.st=void 0,this.q!==R.Reconnecting)return void this.u.log(e.Debug,"Connection left the reconnecting state during reconnect delay. Done reconnecting.");try{if(await this.F(),this.q=R.Connected,this.u.log(e.Information,"HubConnection reconnected successfully."),0!==this.U.length)try{this.U.forEach((t=>t.apply(this,[this.connection.connectionId])))}catch(t){this.u.log(e.Error,`An onreconnected callback called with connectionId '${this.connection.connectionId}; threw error '${t}'.`)}return}catch(t){if(this.u.log(e.Information,`Reconnect attempt failed because of error '${t}'.`),this.q!==R.Reconnecting)return this.u.log(e.Debug,`Connection moved to the '${this.q}' from the reconnecting state during reconnect attempt. Done reconnecting.`),void(this.q===R.Disconnecting&&this.nt());i=t instanceof Error?t:new Error(t.toString()),r=this.yt(n++,Date.now()-s,i)}}this.u.log(e.Information,`Reconnect retries have been exhausted after ${Date.now()-s} ms and ${n} failed attempts. Connection disconnecting.`),this.nt()}yt(t,s,n){try{return this.P.nextRetryDelayInMilliseconds({elapsedMilliseconds:s,previousRetryCount:t,retryReason:n})}catch(n){return this.u.log(e.Error,`IRetryPolicy.nextRetryDelayInMilliseconds(${t}, ${s}) threw error '${n}'.`),null}}wt(t){const s=this.H;this.H={},Object.keys(s).forEach((n=>{const i=s[n];try{i(null,t)}catch(s){this.u.log(e.Error,`Stream 'error' callback called with '${t}' threw error: ${P(s)}`)}}))}Z(){this.ft&&(clearTimeout(this.ft),this.ft=void 0)}G(){this.dt&&clearTimeout(this.dt)}at(t,e,s,n){if(s)return 0!==n.length?{arguments:e,streamIds:n,target:t,type:A.Invocation}:{arguments:e,target:t,type:A.Invocation};{const s=this.N;return this.N++,0!==n.length?{arguments:e,invocationId:s.toString(),streamIds:n,target:t,type:A.Invocation}:{arguments:e,invocationId:s.toString(),target:t,type:A.Invocation}}}ct(t,e){if(0!==t.length){e||(e=Promise.resolve());for(const s in t)t[s].subscribe({complete:()=>{e=e.then((()=>this.ht(this.bt(s))))},error:t=>{let n;n=t instanceof Error?t.message:t&&t.toString?t.toString():"Unknown error",e=e.then((()=>this.ht(this.bt(s,n))))},next:t=>{e=e.then((()=>this.ht(this.vt(s,t))))}})}}it(t){const e=[],s=[];for(let n=0;n<t.length;n++){const i=t[n];if(this.Et(i)){const r=this.N;this.N++,e[r]=i,s.push(r.toString()),t.splice(n,1)}}return[e,s]}Et(t){return t&&t.subscribe&&"function"==typeof t.subscribe}rt(t,e,s){const n=this.N;return this.N++,0!==s.length?{arguments:e,invocationId:n.toString(),streamIds:s,target:t,type:A.StreamInvocation}:{arguments:e,invocationId:n.toString(),target:t,type:A.StreamInvocation}}ot(t){return{invocationId:t,type:A.CancelInvocation}}vt(t,e){return{invocationId:t,item:e,type:A.StreamItem}}bt(t,e,s){return e?{error:e,invocationId:t,type:A.Completion}:{invocationId:t,result:s,type:A.Completion}}}const L=[0,2e3,1e4,3e4,null];class q{constructor(t){this.$t=void 0!==t?[...t,null]:L}nextRetryDelayInMilliseconds(t){return this.$t[t.previousRetryCount]}}class j{}var M,W;j.Authorization="Authorization",j.Cookie="Cookie",function(t){t[t.None=0]="None",t[t.WebSockets=1]="WebSockets",t[t.ServerSentEvents=2]="ServerSentEvents",t[t.LongPolling=4]="LongPolling"}(M||(M={})),function(t){t[t.Text=1]="Text",t[t.Binary=2]="Binary"}(W||(W={}));class O{constructor(){this.Ct=!1,this.onabort=null}abort(){this.Ct||(this.Ct=!0,this.onabort&&this.onabort())}get signal(){return this}get aborted(){return this.Ct}}class F{constructor(t,e,s,n){this.$=t,this.St=e,this.u=s,this.kt=new O,this.Pt=n,this.Tt=!1,this.onreceive=null,this.onclose=null}get pollAborted(){return this.kt.aborted}async connect(t,s){if(w.isRequired(t,"url"),w.isRequired(s,"transferFormat"),w.isIn(s,W,"transferFormat"),this.It=t,this.u.log(e.Trace,"(LongPolling transport) Connecting."),s===W.Binary&&"undefined"!=typeof XMLHttpRequest&&"string"!=typeof(new XMLHttpRequest).responseType)throw new Error("Binary protocols over XmlHttpRequest not implementing advanced features are not supported.");const[i,r]=$(),o={[i]:r,...this.Pt.headers},h={abortSignal:this.kt.signal,headers:o,timeout:1e5,withCredentials:this.Pt.withCredentials};s===W.Binary&&(h.responseType="arraybuffer");const c=await this._t();this.Ht(h,c);const a=`${t}&_=${Date.now()}`;this.u.log(e.Trace,`(LongPolling transport) polling: ${a}.`);const l=await this.$.get(a,h);200!==l.statusCode?(this.u.log(e.Error,`(LongPolling transport) Unexpected response code: ${l.statusCode}.`),this.Dt=new n(l.statusText||"",l.statusCode),this.Tt=!1):this.Tt=!0,this.xt=this.At(this.It,h)}async _t(){return this.St?await this.St():null}Ht(t,e){t.headers||(t.headers={}),e?t.headers[j.Authorization]=`Bearer ${e}`:t.headers[j.Authorization]&&delete t.headers[j.Authorization]}async At(t,s){try{for(;this.Tt;){const r=await this._t();this.Ht(s,r);try{const i=`${t}&_=${Date.now()}`;this.u.log(e.Trace,`(LongPolling transport) polling: ${i}.`);const r=await this.$.get(i,s);204===r.statusCode?(this.u.log(e.Information,"(LongPolling transport) Poll terminated by server."),this.Tt=!1):200!==r.statusCode?(this.u.log(e.Error,`(LongPolling transport) Unexpected response code: ${r.statusCode}.`),this.Dt=new n(r.statusText||"",r.statusCode),this.Tt=!1):r.content?(this.u.log(e.Trace,`(LongPolling transport) data received. ${y(r.content,this.Pt.logMessageContent)}.`),this.onreceive&&this.onreceive(r.content)):this.u.log(e.Trace,"(LongPolling transport) Poll timed out, reissuing.")}catch(t){this.Tt?t instanceof i?this.u.log(e.Trace,"(LongPolling transport) Poll timed out, reissuing."):(this.Dt=t,this.Tt=!1):this.u.log(e.Trace,`(LongPolling transport) Poll errored after shutdown: ${t.message}`)}}}finally{this.u.log(e.Trace,"(LongPolling transport) Polling complete."),this.pollAborted||this.Rt()}}async send(t){return this.Tt?b(this.u,"LongPolling",this.$,this.It,this.St,t,this.Pt):Promise.reject(new Error("Cannot send until the transport is connected"))}async stop(){this.u.log(e.Trace,"(LongPolling transport) Stopping polling."),this.Tt=!1,this.kt.abort();try{await this.xt,this.u.log(e.Trace,`(LongPolling transport) sending DELETE request to ${this.It}.`);const t={},[s,n]=$();t[s]=n;const i={headers:{...t,...this.Pt.headers},timeout:this.Pt.timeout,withCredentials:this.Pt.withCredentials},r=await this._t();this.Ht(i,r),await this.$.delete(this.It,i),this.u.log(e.Trace,"(LongPolling transport) DELETE request sent.")}finally{this.u.log(e.Trace,"(LongPolling transport) Stop finished."),this.Rt()}}Rt(){if(this.onclose){let t="(LongPolling transport) Firing onclose event.";this.Dt&&(t+=" Error: "+this.Dt),this.u.log(e.Trace,t),this.onclose(this.Dt)}}}class B{constructor(t,e,s,n){this.$=t,this.St=e,this.u=s,this.Pt=n,this.onreceive=null,this.onclose=null}async connect(t,s){if(w.isRequired(t,"url"),w.isRequired(s,"transferFormat"),w.isIn(s,W,"transferFormat"),this.u.log(e.Trace,"(SSE transport) Connecting."),this.It=t,this.St){const e=await this.St();e&&(t+=(t.indexOf("?")<0?"?":"&")+`access_token=${encodeURIComponent(e)}`)}return new Promise(((n,i)=>{let r,o=!1;if(s===W.Text){if(g.isBrowser||g.isWebWorker)r=new this.Pt.EventSource(t,{withCredentials:this.Pt.withCredentials});else{const e=this.$.getCookieString(t),s={};s.Cookie=e;const[n,i]=$();s[n]=i,r=new this.Pt.EventSource(t,{withCredentials:this.Pt.withCredentials,headers:{...s,...this.Pt.headers}})}try{r.onmessage=t=>{if(this.onreceive)try{this.u.log(e.Trace,`(SSE transport) data received. ${y(t.data,this.Pt.logMessageContent)}.`),this.onreceive(t.data)}catch(t){return void this.Ut(t)}},r.onerror=t=>{o?this.Ut():i(new Error("EventSource failed to connect. The connection could not be found on the server, either the connection ID is not present on the server, or a proxy is refusing/buffering the connection. If you have multiple servers check that sticky sessions are enabled."))},r.onopen=()=>{this.u.log(e.Information,`SSE connected to ${this.It}`),this.Nt=r,o=!0,n()}}catch(t){return void i(t)}}else i(new Error("The Server-Sent Events transport only supports the 'Text' transfer format"))}))}async send(t){return this.Nt?b(this.u,"SSE",this.$,this.It,this.St,t,this.Pt):Promise.reject(new Error("Cannot send until the transport is connected"))}stop(){return this.Ut(),Promise.resolve()}Ut(t){this.Nt&&(this.Nt.close(),this.Nt=void 0,this.onclose&&this.onclose(t))}}class X{constructor(t,e,s,n,i,r){this.u=s,this.St=e,this.Lt=n,this.qt=i,this.$=t,this.onreceive=null,this.onclose=null,this.jt=r}async connect(t,s){if(w.isRequired(t,"url"),w.isRequired(s,"transferFormat"),w.isIn(s,W,"transferFormat"),this.u.log(e.Trace,"(WebSockets transport) Connecting."),this.St){const e=await this.St();e&&(t+=(t.indexOf("?")<0?"?":"&")+`access_token=${encodeURIComponent(e)}`)}return new Promise(((n,i)=>{let r;t=t.replace(/^http/,"ws");const o=this.$.getCookieString(t);let h=!1;if(g.isNode){const e={},[s,n]=$();e[s]=n,o&&(e[j.Cookie]=`${o}`),r=new this.qt(t,void 0,{headers:{...e,...this.jt}})}r||(r=new this.qt(t)),s===W.Binary&&(r.binaryType="arraybuffer"),r.onopen=s=>{this.u.log(e.Information,`WebSocket connected to ${t}.`),this.Mt=r,h=!0,n()},r.onerror=t=>{let s=null;s="undefined"!=typeof ErrorEvent&&t instanceof ErrorEvent?t.error:"There was an error with the transport",this.u.log(e.Information,`(WebSockets transport) ${s}.`)},r.onmessage=t=>{if(this.u.log(e.Trace,`(WebSockets transport) data received. ${y(t.data,this.Lt)}.`),this.onreceive)try{this.onreceive(t.data)}catch(t){return void this.Ut(t)}},r.onclose=t=>{if(h)this.Ut(t);else{let e=null;e="undefined"!=typeof ErrorEvent&&t instanceof ErrorEvent?t.error:"WebSocket failed to connect. The connection could not be found on the server, either the endpoint may not be a SignalR endpoint, the connection ID is not present on the server, or there is a proxy blocking WebSockets. If you have multiple servers check that sticky sessions are enabled.",i(new Error(e))}}}))}send(t){return this.Mt&&this.Mt.readyState===this.qt.OPEN?(this.u.log(e.Trace,`(WebSockets transport) sending data. ${y(t,this.Lt)}.`),this.Mt.send(t),Promise.resolve()):Promise.reject("WebSocket is not in the OPEN state")}stop(){return this.Mt&&this.Ut(void 0),Promise.resolve()}Ut(t){this.Mt&&(this.Mt.onclose=()=>{},this.Mt.onmessage=()=>{},this.Mt.onerror=()=>{},this.Mt.close(),this.Mt=void 0),this.u.log(e.Trace,"(WebSockets transport) socket closed."),this.onclose&&(!this.Wt(t)||!1!==t.wasClean&&1e3===t.code?t instanceof Error?this.onclose(t):this.onclose():this.onclose(new Error(`WebSocket closed with status code: ${t.code} (${t.reason||"no reason given"}).`)))}Wt(t){return t&&"boolean"==typeof t.wasClean&&"number"==typeof t.code}}class J{constructor(t,s={}){var n;if(this.Ot=()=>{},this.features={},this.Ft=1,w.isRequired(t,"url"),this.u=void 0===(n=s.logger)?new E(e.Information):null===n?f.instance:void 0!==n.log?n:new E(n),this.baseUrl=this.Bt(t),(s=s||{}).logMessageContent=void 0!==s.logMessageContent&&s.logMessageContent,"boolean"!=typeof s.withCredentials&&void 0!==s.withCredentials)throw new Error("withCredentials option was not a 'boolean' or 'undefined' value");s.withCredentials=void 0===s.withCredentials||s.withCredentials,s.timeout=void 0===s.timeout?1e5:s.timeout;let i=null,r=null;if(g.isNode){const t=require;i=t("ws"),r=t("eventsource")}g.isNode||"undefined"==typeof WebSocket||s.WebSocket?g.isNode&&!s.WebSocket&&i&&(s.WebSocket=i):s.WebSocket=WebSocket,g.isNode||"undefined"==typeof EventSource||s.EventSource?g.isNode&&!s.EventSource&&void 0!==r&&(s.EventSource=r):s.EventSource=EventSource,this.$=s.httpClient||new H(this.u),this.q="Disconnected",this.j=!1,this.Pt=s,this.onreceive=null,this.onclose=null}async start(t){if(t=t||W.Binary,w.isIn(t,W,"transferFormat"),this.u.log(e.Debug,`Starting connection with transfer format '${W[t]}'.`),"Disconnected"!==this.q)return Promise.reject(new Error("Cannot start an HttpConnection that is not in the 'Disconnected' state."));if(this.q="Connecting",this.Xt=this.F(t),await this.Xt,"Disconnecting"===this.q){const t="Failed to start the HttpConnection before stop() was called.";return this.u.log(e.Error,t),await this.tt,Promise.reject(new Error(t))}if("Connected"!==this.q){const t="HttpConnection.startInternal completed gracefully but didn't enter the connection into the connected state!";return this.u.log(e.Error,t),Promise.reject(new Error(t))}this.j=!0}send(t){return"Connected"!==this.q?Promise.reject(new Error("Cannot send data if the connection is not in the 'Connected' State.")):(this.Jt||(this.Jt=new z(this.transport)),this.Jt.send(t))}async stop(t){return"Disconnected"===this.q?(this.u.log(e.Debug,`Call to HttpConnection.stop(${t}) ignored because the connection is already in the disconnected state.`),Promise.resolve()):"Disconnecting"===this.q?(this.u.log(e.Debug,`Call to HttpConnection.stop(${t}) ignored because the connection is already in the disconnecting state.`),this.tt):(this.q="Disconnecting",this.tt=new Promise((t=>{this.Ot=t})),await this.et(t),void await this.tt)}async et(t){this.zt=t;try{await this.Xt}catch(t){}if(this.transport){try{await this.transport.stop()}catch(t){this.u.log(e.Error,`HttpConnection.transport.stop() threw error '${t}'.`),this.Vt()}this.transport=void 0}else this.u.log(e.Debug,"HttpConnection.transport is undefined in HttpConnection.stop() because start() failed.")}async F(t){let s=this.baseUrl;this.St=this.Pt.accessTokenFactory;try{if(this.Pt.skipNegotiation){if(this.Pt.transport!==M.WebSockets)throw new Error("Negotiation can only be skipped when using the WebSocket transport directly.");this.transport=this.Gt(M.WebSockets),await this.Kt(s,t)}else{let e=null,n=0;do{if(e=await this.Qt(s),"Disconnecting"===this.q||"Disconnected"===this.q)throw new Error("The connection was stopped during negotiation.");if(e.error)throw new Error(e.error);if(e.ProtocolVersion)throw new Error("Detected a connection attempt to an ASP.NET SignalR Server. This client only supports connecting to an ASP.NET Core SignalR Server. See https://aka.ms/signalr-core-differences for details.");if(e.url&&(s=e.url),e.accessToken){const t=e.accessToken;this.St=()=>t}n++}while(e.url&&n<100);if(100===n&&e.url)throw new Error("Negotiate redirection limit exceeded.");await this.Yt(s,this.Pt.transport,e,t)}this.transport instanceof F&&(this.features.inherentKeepAlive=!0),"Connecting"===this.q&&(this.u.log(e.Debug,"The HttpConnection connected successfully."),this.q="Connected")}catch(t){return this.u.log(e.Error,"Failed to start the connection: "+t),this.q="Disconnected",this.transport=void 0,this.Ot(),Promise.reject(t)}}async Qt(t){const s={};if(this.St){const t=await this.St();t&&(s[j.Authorization]=`Bearer ${t}`)}const[i,r]=$();s[i]=r;const o=this.Zt(t);this.u.log(e.Debug,`Sending negotiation request: ${o}.`);try{const t=await this.$.post(o,{content:"",headers:{...s,...this.Pt.headers},timeout:this.Pt.timeout,withCredentials:this.Pt.withCredentials});if(200!==t.statusCode)return Promise.reject(new Error(`Unexpected status code returned from negotiate '${t.statusCode}'`));const e=JSON.parse(t.content);return(!e.negotiateVersion||e.negotiateVersion<1)&&(e.connectionToken=e.connectionId),e}catch(t){let s="Failed to complete negotiation with the server: "+t;return t instanceof n&&404===t.statusCode&&(s+=" Either this is not a SignalR endpoint or there is a proxy blocking the connection."),this.u.log(e.Error,s),Promise.reject(new a(s))}}te(t,e){return e?t+(-1===t.indexOf("?")?"?":"&")+`id=${e}`:t}async Yt(t,s,n,i){let r=this.te(t,n.connectionToken);if(this.ee(s))return this.u.log(e.Debug,"Connection was provided an instance of ITransport, using that directly."),this.transport=s,await this.Kt(r,i),void(this.connectionId=n.connectionId);const o=[],h=n.availableTransports||[];let a=n;for(const n of h){const h=this.se(n,s,i);if(h instanceof Error)o.push(`${n.transport} failed:`),o.push(h);else if(this.ee(h)){if(this.transport=h,!a){try{a=await this.Qt(t)}catch(t){return Promise.reject(t)}r=this.te(t,a.connectionToken)}try{return await this.Kt(r,i),void(this.connectionId=a.connectionId)}catch(t){if(this.u.log(e.Error,`Failed to start the transport '${n.transport}': ${t}`),a=void 0,o.push(new c(`${n.transport} failed: ${t}`,M[n.transport])),"Connecting"!==this.q){const t="Failed to select transport before stop() was called.";return this.u.log(e.Debug,t),Promise.reject(new Error(t))}}}}return o.length>0?Promise.reject(new l(`Unable to connect to the server with any of the available transports. ${o.join(" ")}`,o)):Promise.reject(new Error("None of the transports supported by the client are supported by the server."))}Gt(t){switch(t){case M.WebSockets:if(!this.Pt.WebSocket)throw new Error("'WebSocket' is not supported in your environment.");return new X(this.$,this.St,this.u,this.Pt.logMessageContent,this.Pt.WebSocket,this.Pt.headers||{});case M.ServerSentEvents:if(!this.Pt.EventSource)throw new Error("'EventSource' is not supported in your environment.");return new B(this.$,this.St,this.u,this.Pt);case M.LongPolling:return new F(this.$,this.St,this.u,this.Pt);default:throw new Error(`Unknown transport: ${t}.`)}}Kt(t,e){return this.transport.onreceive=this.onreceive,this.transport.onclose=t=>this.Vt(t),this.transport.connect(t,e)}se(t,s,n){const i=M[t.transport];if(null==i)return this.u.log(e.Debug,`Skipping transport '${t.transport}' because it is not supported by this client.`),new Error(`Skipping transport '${t.transport}' because it is not supported by this client.`);if(!function(t,e){return!t||0!=(e&t)}(s,i))return this.u.log(e.Debug,`Skipping transport '${M[i]}' because it was disabled by the client.`),new h(`'${M[i]}' is disabled by the client.`,i);if(!(t.transferFormats.map((t=>W[t])).indexOf(n)>=0))return this.u.log(e.Debug,`Skipping transport '${M[i]}' because it does not support the requested transfer format '${W[n]}'.`),new Error(`'${M[i]}' does not support ${W[n]}.`);if(i===M.WebSockets&&!this.Pt.WebSocket||i===M.ServerSentEvents&&!this.Pt.EventSource)return this.u.log(e.Debug,`Skipping transport '${M[i]}' because it is not supported in your environment.'`),new o(`'${M[i]}' is not supported in your environment.`,i);this.u.log(e.Debug,`Selecting transport '${M[i]}'.`);try{return this.Gt(i)}catch(t){return t}}ee(t){return t&&"object"==typeof t&&"connect"in t}Vt(t){if(this.u.log(e.Debug,`HttpConnection.stopConnection(${t}) called while in state ${this.q}.`),this.transport=void 0,t=this.zt||t,this.zt=void 0,"Disconnected"!==this.q){if("Connecting"===this.q)throw this.u.log(e.Warning,`Call to HttpConnection.stopConnection(${t}) was ignored because the connection is still in the connecting state.`),new Error(`HttpConnection.stopConnection(${t}) was called while the connection is still in the connecting state.`);if("Disconnecting"===this.q&&this.Ot(),t?this.u.log(e.Error,`Connection disconnected with error '${t}'.`):this.u.log(e.Information,"Connection disconnected."),this.Jt&&(this.Jt.stop().catch((t=>{this.u.log(e.Error,`TransportSendQueue.stop() threw error '${t}'.`)})),this.Jt=void 0),this.connectionId=void 0,this.q="Disconnected",this.j){this.j=!1;try{this.onclose&&this.onclose(t)}catch(s){this.u.log(e.Error,`HttpConnection.onclose(${t}) threw error '${s}'.`)}}}else this.u.log(e.Debug,`Call to HttpConnection.stopConnection(${t}) was ignored because the connection is already in the disconnected state.`)}Bt(t){if(0===t.lastIndexOf("https://",0)||0===t.lastIndexOf("http://",0))return t;if(!g.isBrowser)throw new Error(`Cannot resolve '${t}'.`);const s=window.document.createElement("a");return s.href=t,this.u.log(e.Information,`Normalizing '${t}' to '${s.href}'.`),s.href}Zt(t){const e=t.indexOf("?");let s=t.substring(0,-1===e?t.length:e);return"/"!==s[s.length-1]&&(s+="/"),s+="negotiate",s+=-1===e?"":t.substring(e),-1===s.indexOf("negotiateVersion")&&(s+=-1===e?"?":"&",s+="negotiateVersion="+this.Ft),s}}class z{constructor(t){this.ne=t,this.ie=[],this.re=!0,this.oe=new V,this.he=new V,this.ce=this.ae()}send(t){return this.le(t),this.he||(this.he=new V),this.he.promise}stop(){return this.re=!1,this.oe.resolve(),this.ce}le(t){if(this.ie.length&&typeof this.ie[0]!=typeof t)throw new Error(`Expected data to be of type ${typeof this.ie} but was of type ${typeof t}`);this.ie.push(t),this.oe.resolve()}async ae(){for(;;){if(await this.oe.promise,!this.re){this.he&&this.he.reject("Connection stopped.");break}this.oe=new V;const t=this.he;this.he=void 0;const e="string"==typeof this.ie[0]?this.ie.join(""):z.ue(this.ie);this.ie.length=0;try{await this.ne.send(e),t.resolve()}catch(e){t.reject(e)}}}static ue(t){const e=t.map((t=>t.byteLength)).reduce(((t,e)=>t+e)),s=new Uint8Array(e);let n=0;for(const e of t)s.set(new Uint8Array(e),n),n+=e.byteLength;return s.buffer}}class V{constructor(){this.promise=new Promise(((t,e)=>[this.de,this.fe]=[t,e]))}resolve(){this.de()}reject(t){this.fe(t)}}class G{constructor(){this.name="json",this.version=1,this.transferFormat=W.Text}parseMessages(t,s){if("string"!=typeof t)throw new Error("Invalid input for JSON hub protocol. Expected a string.");if(!t)return[];null===s&&(s=f.instance);const n=D.parse(t),i=[];for(const t of n){const n=JSON.parse(t);if("number"!=typeof n.type)throw new Error("Invalid payload.");switch(n.type){case A.Invocation:this.pe(n);break;case A.StreamItem:this.we(n);break;case A.Completion:this.ge(n);break;case A.Ping:case A.Close:break;default:s.log(e.Information,"Unknown message type '"+n.type+"' ignored.");continue}i.push(n)}return i}writeMessage(t){return D.write(JSON.stringify(t))}pe(t){this.ye(t.target,"Invalid payload for Invocation message."),void 0!==t.invocationId&&this.ye(t.invocationId,"Invalid payload for Invocation message.")}we(t){if(this.ye(t.invocationId,"Invalid payload for StreamItem message."),void 0===t.item)throw new Error("Invalid payload for StreamItem message.")}ge(t){if(t.result&&t.error)throw new Error("Invalid payload for Completion message.");!t.result&&t.error&&this.ye(t.error,"Invalid payload for Completion message."),this.ye(t.invocationId,"Invalid payload for Completion message.")}ye(t,e){if("string"!=typeof t||""===t)throw new Error(e)}}const K={trace:e.Trace,debug:e.Debug,info:e.Information,information:e.Information,warn:e.Warning,warning:e.Warning,error:e.Error,critical:e.Critical,none:e.None};class Q{configureLogging(t){if(w.isRequired(t,"logging"),void 0!==t.log)this.logger=t;else if("string"==typeof t){const e=function(t){const e=K[t.toLowerCase()];if(void 0!==e)return e;throw new Error(`Unknown log level: ${t}`)}(t);this.logger=new E(e)}else this.logger=new E(t);return this}withUrl(t,e){return w.isRequired(t,"url"),w.isNotEmpty(t,"url"),this.url=t,this.httpConnectionOptions="object"==typeof e?{...this.httpConnectionOptions,...e}:{...this.httpConnectionOptions,transport:e},this}withHubProtocol(t){return w.isRequired(t,"protocol"),this.protocol=t,this}withAutomaticReconnect(t){if(this.reconnectPolicy)throw new Error("A reconnectPolicy has already been set.");return t?Array.isArray(t)?this.reconnectPolicy=new q(t):this.reconnectPolicy=t:this.reconnectPolicy=new q,this}build(){const t=this.httpConnectionOptions||{};if(void 0===t.logger&&(t.logger=this.logger),!this.url)throw new Error("The 'HubConnectionBuilder.withUrl' method must be called before building the connection.");const e=new J(this.url,t);return N.create(e,this.logger||f.instance,this.protocol||new G,this.reconnectPolicy)}}return Uint8Array.prototype.indexOf||Object.defineProperty(Uint8Array.prototype,"indexOf",{value:Array.prototype.indexOf,writable:!0}),Uint8Array.prototype.slice||Object.defineProperty(Uint8Array.prototype,"slice",{value:function(t,e){return new Uint8Array(Array.prototype.slice.call(this,t,e))},writable:!0}),Uint8Array.prototype.forEach||Object.defineProperty(Uint8Array.prototype,"forEach",{value:Array.prototype.forEach,writable:!0}),s})()},"object"==typeof exports&&"object"==typeof module?module.exports=e():"function"==typeof define&&define.amd?define([],e):"object"==typeof exports?exports.signalR=e():t.signalR=e();
//# sourceMappingURL=signalr.min.js.map

$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7035/testhub").build();
    connection.start().then(() => {
        console.log(connection.state);
        connection.invoke("SendMessage");
    }).catch((err) => { console.log(err) });


    connection.on("ReceiveMessage", (value) => {
        playNotificationSound();
        toastr.success(value, 'SignalR Bildirim')
        Utils.getAppUserList();
        Utils.getAssignedUserList();
        
    });
    function playNotificationSound() {
        var notifySound = new Audio('/notifySound.wav');
        notifySound.play().then(() => {

        }).catch(error => {
            console.log('Bildirim Sesi Calinamadi : ',error)
        })
    }

});

/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});



var Config = {
    notifyAppUserUrl: "https://localhost:7035/api/ClientNotifications/bildirim-listesi?notifyType=1",
    notifyAssignedUserUrl: "https://localhost:7035/api/ClientNotifications/bildirim-listesi?notifyType=2"
};

$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7035/testhub").build();
    connection.start().then(() => {
        console.log(connection.state);
        connection.invoke("SendMessage");
    }).catch((err) => { console.log(err) });


    connection.on("ReceiveMessage", (value) => {
        playNotificationSound();
        toastr.success(value, 'SignalR Bildirim')
        Utils.getAppUserList();
        Utils.getAssignedUserList();
        
    });
    function playNotificationSound() {
        var notifySound = new Audio('/notifySound.wav');
        notifySound.play().then(() => {

        }).catch(error => {
            console.log('Bildirim Sesi Calinamadi : ',error)
        })
    }

});




var Utils = {
    getAppUserList: function getAppUserList() {
        NotifyService.getNotifyList()
            .then(function (data) {
                if (data != null) {
                    const div = document.getElementById('messageCount');
                    div.innerHTML = data.length;
                    data.forEach(item => {
                        const container = document.getElementById('container');
                        container.innerHTML = '';
                        data.forEach(item => {
                            var options = {
                                year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric'
                            }
                            var createdDate = new Date(item.createdDate);
                            var formattedDate = createdDate.toLocaleString("tr-TR", options);

                            const htmlCode = `<a class="dropdown-item d-flex align-items-center" href="/Home/TodoDetails/${item.todoId}"  target="_blank">
                                                    <div class="font-weight-bold">
                                                        
                                                        <div class="text-truncate">${item.appUserName} - Bildirdiklerinizden (${item.todoId}) Nolu Bildirim</div>
                                                        <div class="small">${item.assignedUserName} <span>${formattedDate}</span> </div>
                                                    </div>
                                                </a>`;
                            container.insertAdjacentHTML('beforeend', htmlCode);
                        });
                    })
                }
            });
    },
    getAssignedUserList: function getAssignedUserList() {
        NotifyService.getNotifyListAssigned()
            .then((datas) => {
                if (datas != null) {
                    const countDiv = document.getElementById('messageCountAssigned');
                    countDiv.innerHTML = datas.length;
                    const contentDiv = document.getElementById('container_assigned');
                    contentDiv.innerHTML = '';
                    datas.forEach(item => {
                        var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
                        var createdDate = new Date(item.createdDate);
                        var formattedDate = createdDate.toLocaleString("tr-TR", options);

                        const contentHtmlCode = `<a  class="dropdown-item d-flex align-items-center" href="/Home/TodoDetails/${item.todoId}"  target="_blank">
                                                    <div class="font-weight-bold">  
                                                        <div class="text-truncate">${item.assignedUserName} - Size Atananlardan (${item.todoId}) Nolu Bildirim</div>
                                                        <div class="small">${item.appUserName} <span>${formattedDate}</span> </div>
                                                    </div>
                                                </a>`;
                        contentDiv.insertAdjacentHTML('beforeend', contentHtmlCode);

                    })
                }
            });
    }
}

Utils.getAppUserList();
Utils.getAssignedUserList();





$('#messagesDropdown').click(function () {
    Utils.getAppUserList();
})
$('#messagesDropdownAssigned').click(function () {
    Utils.getAssignedUserList();
})
$('#container_assigned').click(() => {
    setTimeout(() => {
        Utils.getAssignedUserList();
    }, 1000)

});
$('#container').click(() => {
    setTimeout(() => {
        Utils.getAppUserList();
    }, 1000)

});
