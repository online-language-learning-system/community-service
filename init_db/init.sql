
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'community_db')
BEGIN
    CREATE DATABASE community_db;
END;
GO

USE community_db;
GO

IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = 'app')
BEGIN
    EXEC('CREATE SCHEMA app');
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'app.communities') AND type = 'U')
BEGIN
    CREATE TABLE app.communities (
        id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        name            VARCHAR(255) NOT NULL,
        description     VARCHAR(1000) NULL,
        created_by      UNIQUEIDENTIFIER NOT NULL,
        created_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
        updated_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'app.posts') AND type = 'U')
BEGIN
    CREATE TABLE app.posts (
        id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        community_id    UNIQUEIDENTIFIER NOT NULL,
        author_id       UNIQUEIDENTIFIER NOT NULL,
        title           VARCHAR(255) NOT NULL,
        content         VARCHAR(MAX) NOT NULL,
        created_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
        updated_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
    );
END;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'app.comments') AND type = 'U')
BEGIN
    CREATE TABLE app.comments (
        id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        post_id         UNIQUEIDENTIFIER NOT NULL,
        author_id       UNIQUEIDENTIFIER NOT NULL,
        content         VARCHAR(MAX) NOT NULL,
        created_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
        updated_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
    );
END;
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'app.bookmarks') AND type = 'U')
BEGIN
    CREATE TABLE app.bookmarks (
        id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        user_id         UNIQUEIDENTIFIER NOT NULL,
        post_id         UNIQUEIDENTIFIER NOT NULL,
        created_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
    );
END;
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'app.reactions') AND type = 'U')
BEGIN
    CREATE TABLE app.reactions (
        id              UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        user_id         UNIQUEIDENTIFIER NOT NULL,
        post_id         UNIQUEIDENTIFIER NOT NULL,
        type            VARCHAR(50) NOT NULL, 
        created_at      DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET()
    );
END;
GO

DECLARE @communityId UNIQUEIDENTIFIER = NEWID();
DECLARE @userId UNIQUEIDENTIFIER = NEWID();

INSERT INTO app.communities (id, name, description, created_by)
VALUES (@communityId, 'Tech Community', 'A place to discuss technology', @userId);

DECLARE @postId UNIQUEIDENTIFIER = NEWID();

INSERT INTO app.posts (id, community_id, author_id, title, content)
VALUES (@postId, @communityId, @userId, 'Hello World', 'This is the first seeded post');


INSERT INTO app.comments (post_id, author_id, content)
VALUES (@postId, @userId, 'This is a sample comment');


INSERT INTO app.bookmarks (user_id, post_id)
VALUES (@userId, @postId);


INSERT INTO app.reactions (user_id, post_id, type)
VALUES (@userId, @postId, 'like');
GO
USE community_db;
GO


