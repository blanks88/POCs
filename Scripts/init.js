var fs   = require('fs');
var path = require('path');
var exec = require('child_process').exec;
var hiddenHooksFolderPath = path.join(__dirname, '../.git/hooks');
var hooksFolderPath       = path.join(__dirname, 'hooks');
var hooks                 = fs.readdirSync(hooksFolderPath);
function copyFile (source, target, cb) {
    var cbCalled = false;
    var rd       = fs.createReadStream(source);
    var wr       = fs.createWriteStream(target);
    function done(err) {
        if (!cbCalled) {
            cb(err);
            cbCalled = true;
        }
    }
    rd.on("error", done);
    wr.on("error", done);
    wr.on("close", done);
    rd.pipe(wr);
}
hooks.forEach(function (hook) {
    var hookSource = path.join(hooksFolderPath, hook);
    var hookTarget = path.join(hiddenHooksFolderPath, hook);
    copyFile(hookSource, hookTarget, function (err) {
        if (!err) {
            var command = process.platform === "win32"
                ? 'icacls "' + hookTarget + '" /q /c /t /grant Users:F '
                : 'chmod +x ' + hookTarget;
            exec(
                command,
                function (error) {
                    if (error) {
                        console.log(hookTarget + ' failed..', error);
                    }
                }
            );
        }
    })
});

console.log('Hooks updated.. OK!');
