/// <binding AfterBuild='inject, ngConstantsLocal' />
/// <binding AfterBuild='inject' />
var gulp = require('gulp');
var config = require('./gulpconfig')();
var plugins = require('gulp-load-plugins')({ lazy: true });
var del = require('del');


gulp.task('validateScripts',
    function () {

        log('Analyzing source with JSHint and JSCS');

        return gulp.src(config.alljs)
            .pipe(plugins.jshint())
            .pipe(plugins.jshint.reporter('jshint-stylish', { verbose: true }))
            .pipe(plugins.jshint.reporter('fail'));
    });

gulp.task('styles', ['cleanStyles'],
    function () {
        log('Adding browser prefixes to CSS');

        return gulp.src(config.css)
            .pipe(plugins.plumber())
            .pipe(plugins.autoprefixer({ browsers: ['last 2 versions', '> 5%'] }))
            .pipe(gulp.dest(config.dist + 'styles')); //TODO
    });

gulp.task('cleanStyles',
    function () {
        return clean(config.dist + 'styles/**/*.css'); //TODO
    });

gulp.task('styleWatcher',
    function () {
        gulp.watch([config.css], ['styles']);
    });

gulp.task('wiredep',
    function () {
        var options = config.getWiredepDefaultOptions();
        var wiredep = require('wiredep').stream;
        return gulp
            .src(config.index)
            .pipe(wiredep(options))
            .pipe(plugins.inject(gulp.src(config.js)))
            .pipe(gulp.dest('./'));
    });

gulp.task('inject',
    ['wiredep'],
    function () {
        return gulp
            .src(config.index)
            .pipe(plugins.inject(gulp.src(config.dist + 'styles/site.css')))
            .pipe(gulp.dest('./'));
    });

gulp.task('ngConstantsLocal',
    function () {
        gulp
            .src(config.ngConfig)
            .pipe(plugins.ngConfig('app.config', { environment: 'local' }))
            .pipe(gulp.dest('./app/'));
    });

gulp.task('ngConstantsDev',
    function () {
        gulp
            .src(config.ngConfig)
            .pipe(plugins.ngConfig('app.config', { environment: 'development' }))
            .pipe(gulp.dest('./app/'));
    });

gulp.task('ngConstantsProd',
    function () {
        gulp
            .src(config.ngConfig)
            .pipe(plugins.ngConfig('app.config', { environment: 'production' }))
            .pipe(gulp.dest('./app/'));
    });

function clean(path) {
    log('Cleaning: ' + plugins.util.colors.blue(path));
    return del(path);
}

function log(message) {
    if (typeof message === 'object') {
        for (var item in message) {
            if (message.hasOwnProperty(item)) {
                plugins.util.log(plugins.util.colors.blue(message[item]));
            }
        }
    } else {
        plugins.util.log(plugins.util.colors.blue(message));
    }
}