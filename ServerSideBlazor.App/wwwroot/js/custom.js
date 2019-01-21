window.navigationInit = () => {
    $(document).ready(function () {
        $('.sidenav').sidenav();
        $(".dropdown-trigger").dropdown();
    });

    return true;
};

window.sidenavInit = () => {
    $(document).ready(function(){
        $('.collapsible').collapsible();
    });

    return true;
};