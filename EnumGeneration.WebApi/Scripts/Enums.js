var Jedi = {
    Youngling: function () { var fn = function () { return 0; }; fn.Text = "Youngling"; fn.Value = 0; return fn; }(),
    Padawan: function () { var fn = function () { return 1; }; fn.Text = "Padawan"; fn.Value = 1; return fn; }(),
    Knight: function () { var fn = function () { return 2; }; fn.Text = "Knight"; fn.Value = 2; return fn; }(),
    Master: function () { var fn = function () { return 3; }; fn.Text = "Master"; fn.Value = 3; return fn; }(),
};
var LightSaber = {
    Blue: function () { var fn = function () { return 0; }; fn.Text = "Blue"; fn.Value = 0; return fn; }(),
    Green: function () { var fn = function () { return 1; }; fn.Text = "Green"; fn.Value = 1; return fn; }(),
    Red: function () { var fn = function () { return 2; }; fn.Text = "Red"; fn.Value = 2; return fn; }(),
    Purple: function () { var fn = function () { return 3; }; fn.Text = "Purple"; fn.Value = 3; return fn; }(),
};