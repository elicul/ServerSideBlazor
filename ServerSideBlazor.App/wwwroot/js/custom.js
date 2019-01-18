// Define a very simple JavaScript function that just prints
// the input parameter to the browser's console
window.navigationInit = () => {
    $(document).ready(function () {
        $('.sidenav').sidenav();
    });

    // Your function currently has to return something. For demo
    // purposes, we just return `true`.
    return true;
};
