module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        concat: {
            controllers: {
                src: ['Scripts/angular-app/js/**/*Controller.js','Scripts/angular-app/controllers/*.js'],
                dest: 'dist/controllers.js',
            },
            services: {
                src: ['Scripts/angular-app/js/**/*Service.js','Scripts/angular-app/services/*.js'],
                dest: 'dist/services.js',
            },
            directives: {
                src: ['Scripts/angular-app/js/**/*Directive.js','Scripts/angular-app/directives/*.js'],
                dest: 'dist/directives.js',
            },
            filters: {
                src: ['Scripts/angular-app/js/**/*Filter.js','Scripts/angular-app/filters/*.js'],
                dest: 'dist/filters.js',
            },
            css: {
                src: ['Scripts/angular-app/css/*.css'],
                dest: 'dist/main.css',
            },
            libs: {
                //straight to min folder
                src: ['Scripts/lib/*.min.js'],
                dest: 'dist/min/libs.min.js',
            },
        },
        uglify: {
            dist: {
                files: {
                    'dist/min/controllers.min.js': ['dist/controllers.js'],
                    'dist/min/services.min.js': ['dist/services.js'],
                    'dist/min/directives.min.js': ['dist/directives.js'],
                    'dist/min/filters.min.js': ['dist/filters.js'],
                    //'dist/min/main.min.css': ['dist/main.css']
                }
            }
        },
        injector: {
            options: {},
            local_dependencies: {
                files: {
                    'index.html': [ 'Scripts/angular-app/js/**/*Controller.js',
                                    'Scripts/angular-app/**/**/*Controller.js',
                                    'Scripts/angular-app/js/**/*Service.js',
                                    'Scripts/angular-app/**/**/*Service.js',
                                    'Scripts/angular-app/js/**/*Directive.js',
                                    'Scripts/angular-app/**/**/*Directive.js',
                                    'Scripts/angular-app/css/*.css'],
                }
            }
        },
        jshint: {
            files: ['Gruntfile.js'],
            options: {
                // options here to override JSHint defaults
                globals: {
                    jQuery: true,
                    console: true,
                    module: true,
                    document: true
                }
            }
        },
        browserSync: {
            bsFiles: {
                src: ['Scripts/angular-app/css/*.css', 'Scripts/angular-app/**/**/*.js','Scripts/angular-app/js/**/*.js'],
            },
            options: {
                server: {
                    baseDir: "./"
                }
            }
        },
        watch: {
            files: ['<%= jshint.files %>'],
            tasks: ['jshint', 'qunit']
        }
    });

    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-injector');
    grunt.loadNpmTasks('grunt-browser-sync');


    grunt.registerTask('dist', ['concat','uglify','injector']);
    grunt.registerTask('serve', ['browserSync']);

};