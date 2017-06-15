module.exports = function () {

    var config = {
        temp: './.tmp/',
        alljs: [
            './app/**/*.js',
            './*.js'
        ],
        css: './styles/site.css',
        index: './index.html',
        js: [
            './app/app.module.js',
            './app/**/*.module.js',
            './app/**/*.js'
        ],
        dist: './dist/',
        ngConfig: './ngConfig.json',

        bower: {
            json: require('./bower.json'),
            directory: './bower_components',
            ignorePath: '../..'
        }
    };

    config.getWiredepDefaultOptions = function () {
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.igonerPath
        };

        return options;
    };

    return config;
}