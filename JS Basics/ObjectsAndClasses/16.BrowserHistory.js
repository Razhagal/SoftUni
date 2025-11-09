function manageBrowserHistory(browserAndTabsData, actionsArr) {
    const browserData = browserAndTabsData;

    for (const action of actionsArr) {
        if (action === 'Clear History and Cache') {
            browserData["Open Tabs"] = [];
            browserData["Recently Closed"] = [];
            browserData["Browser Logs"] = [];
        } else {
            const [actionName, tabName] = action.split(' ');
            let isActionValid = false;
            if (actionName === 'Open') {
                browserData["Open Tabs"].push(tabName);
                isActionValid = true;
            } else if (actionName === 'Close') {
                const tabIndex = browserData["Open Tabs"].indexOf(tabName);
                if (tabIndex > -1) {
                    browserData["Open Tabs"].splice(tabIndex, 1);
                    browserData["Recently Closed"].push(tabName);
                    isActionValid = true;
                }
            }

            if (isActionValid) {
                browserData["Browser Logs"].push(action);
            }
        }
    }

    console.log(`${browserData["Browser Name"]}`);
    console.log(`Open Tabs: ${browserData["Open Tabs"].join(', ')}`);
    console.log(`Recently Closed: ${browserData["Recently Closed"].join(', ')}`);
    console.log(`Browser Logs: ${browserData["Browser Logs"].join(', ')}`);
}

manageBrowserHistory(
    {"Browser Name":"Google Chrome",
    "Open Tabs":["Facebook","YouTube","Google Translate"],
    "Recently Closed":["Yahoo","Gmail"],
    "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
    ["Close Facebook", "Open StackOverFlow", "Open Google"]
);